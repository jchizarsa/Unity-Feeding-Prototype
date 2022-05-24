using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating(function, start, frequency) is used to call a function repeatedly
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    /// <summary> -- Spawn a random enemy -- </summary>
    void SpawnRandomEnemy(){
        int animalIndex = Random.Range(0, _enemyPrefabs.Length); // Choose a random enemy from the enemy array
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); // Randomly choose a spawn position
        Instantiate(_enemyPrefabs[animalIndex], spawnPos, _enemyPrefabs[animalIndex].transform.rotation); // Instantiate the enemy at the spawn position
    }
}
