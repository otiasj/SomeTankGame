﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float force;
    public float radius;
    public int damages = 25;

    public GameObject explosion;

    void OnCollisionEnter(Collision col)
    {
      triggerExplosionAt(transform);
      Destroy(this.gameObject); //destroy the rocket
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerExplosionAt(transform);
        Destroy(this.gameObject); //destroy the rocket
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
                Enemy enemy = collidedRigidBody.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.takeHit(damages);
                }

                Castle castle = collidedRigidBody.GetComponent<Castle>();
                if (castle != null)
                {
                    castle.takeHit(damages);
                }
            }
        }

    
        GameObject explosionInstance = Instantiate(explosion, target.position, Quaternion.identity);
        Destroy(explosionInstance, 5);//destroy the object after 5seconds
    }
}
