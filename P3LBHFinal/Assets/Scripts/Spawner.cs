using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The prefab of the enemy to spawn
    public int numberOfEnemiesPerWave = 5; // Number of enemies to spawn per wave
    public float timeBetweenWaves = 5f; // Time between each wave
    public float timeBetweenEnemies = 1f; // Time between spawning each enemy within a wave

    private int currentWave = 0; // Current wave number

    void Start()
    {
        // Start spawning waves
        StartCoroutine(SpawnWaves());

       
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            // Increment wave number
            currentWave++;

            UnityEngine.Debug.Log("Spawner started.");

            // Spawn enemies for this wave
            for (int i = 0; i < numberOfEnemiesPerWave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            // Wait for next wave
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        // Instantiate enemy at spawner's position and rotation
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
