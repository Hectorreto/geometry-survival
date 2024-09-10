using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int spawnLimit = 10;
    public float minSpawnRadius = 10f;
    public float maxSpawnRadius = 15f;

    private int spawnCount = 0;

    void Start()
    {
        // Usamos StartCoroutine para poder usar la función WaitForSeconds
        StartCoroutine(SpawnEnemies()); 
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (spawnCount < spawnLimit) 
            {
                Vector2 direction = Random.insideUnitSphere;
                Vector2 spawnPosition = transform.position;
                spawnPosition += direction * (maxSpawnRadius - minSpawnRadius);
                spawnPosition += direction.normalized * minSpawnRadius;

                // Spawn the enemy at the calculated position
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                spawnCount++;

                // Decrease the spawn count when the enemy is destroyed
                enemy.GetComponent<BasicEnemy>().OnDestroy += () => spawnCount--;
            }

            // Wait for the specified interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxSpawnRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, minSpawnRadius);
    }
}
