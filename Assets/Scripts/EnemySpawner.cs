using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public float spawnRadius = 10f;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {        
        player = GameObject.FindWithTag("Player");
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Calculate a random position within the spawn radius
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.z = 0; // Ensure enemies spawn at ground level

            // Check if the spawn position is far away from the player
            if (Vector2.Distance(spawnPosition, player.transform.position) > spawnRadius)
            {
                // Spawn the enemy at the calculated position
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }

            // Wait for the specified interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
