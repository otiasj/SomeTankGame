using UnityEngine;

public class Enemy : MonoBehaviour {
    
    
    public GameObject explosion;
    public Castle target;

    public EnemyType[] enemyObjects;

    private EnemyType activeUnit;

    public void Start()
    {
        int activeUnitIndex = Random.Range(0, enemyObjects.Length);
        setActiveUnit(activeUnitIndex);
    }

    public void setActiveUnit(int index)
    {
        activeUnit = enemyObjects[index];
        activeUnit.prefab.SetActive(true);
    }

    public void takeHit(int hit)
    {
        //Debug.Log("Take Hit " + hit);
        activeUnit.hitPoints = activeUnit.hitPoints - hit;
        if (activeUnit.hitPoints <= 0)
        {
            //Debug.Log("HitPoints " + hitPoints);
            Invoke("explode", 0.5f);   
        }
    }

    public void onReachTarget()
    {
        target.takeHit(activeUnit.damages);
    }

    private void explode()
    {
        Destroy(gameObject, 1);
        GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosionInstance, 12);//destroy the explosion object after 12seconds
    }

  
}
