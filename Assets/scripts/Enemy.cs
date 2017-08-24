using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosion;
    private Castle target;
    private bool isAlive = true;

    public EnemyType[] enemyObjects;

    private EnemyType activeUnit;

    //public void Start()
    //{
    //    int activeUnitIndex = Random.Range(0, enemyObjects.Length);
    //    initActiveUnit(activeUnitIndex);

    //}

    public void initActiveUnit(int index)
    {
        activeUnit = enemyObjects[index];
        activeUnit.prefab.SetActive(true);
        initSpeed(activeUnit.speed);
    }

    private void initSpeed(float speed)
    {
        WaypointAgent waypointAgent = GetComponent<WaypointAgent>();
        waypointAgent.Speed = speed;
    }

    public void setTarget(Castle castle)
    {
        this.target = castle;
    }

    public void takeHit(int hit)
    {
        //Debug.Log("Take Hit " + hit);
        activeUnit.hitPoints = activeUnit.hitPoints - hit;
        if (activeUnit.hitPoints <= 0)
        {
            //Debug.Log("HitPoints " + hitPoints);
            Invoke("explode", 0.5f);
            target.onEnemyHit();
        }
    }

    public void onReachTarget()
    {
        if (target != null)
        {
            target.onEnemyDestroyed();
            target.takeHit(activeUnit.damages);
        }
    }

    private void explode()
    {
        if (isAlive)
        {
            target.onEnemyKilled();
            isAlive = false;

            GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionInstance, 12);//destroy the explosion object after 12seconds
            Destroy(gameObject);
        }
    }


}
