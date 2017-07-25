using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 100f;
    public float rotationSpeed = 10;
    
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

    private void Update()
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
