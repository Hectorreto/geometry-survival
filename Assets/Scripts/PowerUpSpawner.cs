using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUpList;
    [SerializeField] private float spawnRangeX = 7.5f;
    [SerializeField] private float spawnRangeY = 4f;

    [SerializeField] private float firstTimeSec = 60f;
    [SerializeField] private float repeatingTimeSec = 60f;

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", firstTimeSec, repeatingTimeSec);
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        int randomIndex = Random.Range(0, powerUpList.Count);
        GameObject powerup = powerUpList[randomIndex];
        Instantiate(powerup, randomPosition, powerup.transform.rotation);
    }
}
