using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float force;
    public float radius;
    public float effectsRadius;

    public GameObject explosion;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("AAA");
        //if (col.gameObject.CompareTag("Floor"))
       // {
        
            triggerExplosionAt(col.transform);
            //Destroy(this.gameObject);
       // }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BBB");
        //if (col.gameObject.CompareTag("Floor"))
        // {

        triggerExplosionAt(other.transform);
        //Destroy(this.gameObject);
        // }
    }

    private void triggerExplosionAt(Transform target)
    {
        Collider[] colliders = Physics.OverlapSphere(target.position, radius);

        foreach (Collider collided in colliders)
        {
            Rigidbody collidedRigidBody = collided.GetComponent<Rigidbody>();

            if (collidedRigidBody != null)
            {
                collidedRigidBody.AddExplosionForce(force, target.position, radius, .5f, ForceMode.Impulse);
            }
        }

        ParticleSystem[] particleSystems = explosion.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < particleSystems.Length; i++)
        {
            ParticleSystem.ShapeModule shapeModule = particleSystems[i].shape;
            shapeModule.radius = effectsRadius;
        }
        Instantiate(explosion, target.position, Quaternion.identity);
    }
}
