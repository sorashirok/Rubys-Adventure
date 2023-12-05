using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int Fixedrobots;
    Rigidbody2D rigidbody2d;
    

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    
    void Update()
    {
        
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }

       

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collided object has a Rigidbody2D
        Rigidbody2D otherRigidbody = other.collider.GetComponent<Rigidbody2D>();
        if (otherRigidbody != null)
        {
            // Destroy the projectile when it hits a Rigidbody2D
            DestroyProjectile();
        }
       
        
      // If the collided object is an EnemyController, fix it
      EnemyController e = other.collider.GetComponent<EnemyController>();

      if (e != null)
         {
          e.Fix();
         }

       

    }

    void DestroyProjectile()
    {
        // Destroy the projectile
        Destroy(gameObject);
    }



}
