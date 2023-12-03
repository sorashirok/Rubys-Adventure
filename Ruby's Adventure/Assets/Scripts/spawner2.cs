using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner2 : MonoBehaviour
{
    
    [SerializeField] private GameObject enemyPrefab;
    

    private GameObject player;
    public int maxEnemies = 5; // Maximum number of enemies to spawn
    public static int currentEnemies = 0;
    



    void Start()
    {
        player = GameObject.Find("Ruby"); // Make sure to set the correct name or use tags for the player character
        StartCoroutine(SpawnEnemy());
    }


    private IEnumerator SpawnEnemy()
    {
        while (currentEnemies < maxEnemies) // Spawn until the maximum limit is reached
        {
            

            yield return new WaitForSeconds(7f); // Adjust spawn interval as needed

            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

           // Make the enemy follow the player
           EnemyFollowPlayer followScript = newEnemy.GetComponent<EnemyFollowPlayer>();
               if (followScript != null)
                {
                followScript.SetTarget(player.transform);
                }
            currentEnemies++;
            Debug.Log("number of enemies " + currentEnemies);

        }


    }

}
