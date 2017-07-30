using UnityEngine;

public class Enemy : MonoBehaviour {
    public int hitPoints = 100;
    public float speed = 10f;
    public float rotationSpeed = 10;
    public GameObject explosion;

    private Transform target;
    private Transform nextTarget;

    private int waypointIndex = 0;
    private Vector3 currentDirection;
    private Vector3 nextTargetDirection;

    private void Start()
    {
        target = Waypoints.points[0];
        nextTarget = Waypoints.points[1];
    }

    public void takeHit(int hit)
    {
        Debug.Log("Take Hit " + hit);
        hitPoints = hitPoints - hit;
        if (hitPoints <= 0)
        {
            Debug.Log("HitPoints " + hitPoints);
            Invoke("explode", 0.5f);   
        }
    }

    private void explode()
    {
        Destroy(gameObject, 1);
        GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explosionInstance, 12);//destroy the object after 5seconds
    }

    private void Update()
    {
        //move();
    }

    private void move()
    {
        currentDirection = target.position - transform.position;
        nextTargetDirection = nextTarget.position - transform.position;

        transform.Translate(currentDirection.normalized * speed * Time.deltaTime, Space.World);

        Quaternion targetRotation = Quaternion.LookRotation(nextTargetDirection);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            getNextWaypoint();
        }
    }

    void getNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            waypointIndex++;
            target = Waypoints.points[waypointIndex];

            if (waypointIndex + 1 >= Waypoints.points.Length)
            {
                nextTarget = Waypoints.points[waypointIndex];
            }
            else
            {
                nextTarget = Waypoints.points[waypointIndex + 1];
            }
        }
    }
}
