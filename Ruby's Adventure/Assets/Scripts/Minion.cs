using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    
    private int collisionCount = 0;

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            collisionCount++;
            Debug.Log("Number of collisions with Ruby: " + collisionCount);

            if (collisionCount >= 2)
            {
                Debug.Log("Destroying Minion");
                DestroyMinion();
            }
        }

        Projectile cogProjectile = other.gameObject.GetComponent<Projectile>();

        if (cogProjectile != null)
        {
            // Assuming that the cog is the projectile thrown by Ruby
            collisionCount++;
            Debug.Log("Number of collisions with Cog Projectile and ruby : " + collisionCount);

            if (collisionCount >= 2)
            {
                DestroyMinion();
            }
            Destroy(cogProjectile.gameObject);
        }
    }

    void DestroyMinion()
    {
        
      // Decrease the enemy count in the spawner
       spawner2.currentEnemies--;
       Debug.Log("Enemy count decreased to: " + spawner2.currentEnemies);
      
        // Destroy the Minion
        Destroy(gameObject);
    }


}
