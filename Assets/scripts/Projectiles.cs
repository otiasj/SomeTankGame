using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour
{
    private GameObject target;
    private Transform targetPosition;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    public bool followTrajectoryDirection = false;
    public bool followTarget = false;

    public Transform projectile;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    public void FireAt(GameObject target)
    {
        this.target = target;
        targetPosition = target.transform;
        StartCoroutine(SimulateProjectile());
    }


    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        //yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(projectile.position, targetPosition.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float velocityX = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float velocityY = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / velocityX;

        // Rotate projectile to face the target.
        projectile.rotation = Quaternion.LookRotation(targetPosition.position - projectile.position);

        //for calculating the direction
        float elapse_time = 0;
        Vector3 previousPosition = projectile.position;
        Vector3 direction;
        Quaternion previousRotation = projectile.rotation;
        
        while (elapse_time < flightDuration)
        {
            //revert the rotation so that the translation direction remains correct
            if (followTrajectoryDirection) {
                projectile.rotation = previousRotation;
            }

            //update the rotation based on the target direction
            if (followTarget) {
                projectile.rotation = Quaternion.LookRotation(target.transform.position - projectile.position);
                previousRotation = projectile.rotation;
            }

            projectile.Translate(0, (velocityY - (gravity * elapse_time)) * Time.deltaTime, velocityX * Time.deltaTime);           
            
            if (followTrajectoryDirection) {
                direction = (previousPosition - projectile.transform.position).normalized; //normalized to get rid of the distance component
                projectile.rotation = Quaternion.FromToRotation(Vector3.up, direction);
                //Debug.DrawLine(projectile.position, projectile.position + direction * 10, Color.red, Mathf.Infinity);
                //Debug.DrawLine(previousPosition, previousPosition + direction * 10, Color.red, Mathf.Infinity);
            }

            elapse_time += Time.deltaTime;
            previousPosition = projectile.position;
            yield return null;
        }
    }
}
