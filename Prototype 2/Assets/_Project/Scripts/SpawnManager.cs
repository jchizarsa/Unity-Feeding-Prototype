using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float spawnPosXLeft = -25;
    private float spawnPosXRight = 25;
    [SerializeField] private float spawnRangeZ = 5;
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
        Vector3 spawnPosTop = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ); // Randomly choose a spawn position
        Vector3 spawnPosLeft = new Vector3(spawnPosXLeft, 0, Random.Range(0, spawnRangeZ)); // Randomly choose a spawn position
        Vector3 spawnPosRight = new Vector3(spawnPosXRight, 0, Random.Range(0, spawnRangeZ)); // Randomly choose a spawn position
        Quaternion spawnRotationRight = Quaternion.Euler(0, 90, 0); // Set the rotation of the enemy
        Quaternion spawnRotationLeft = Quaternion.Euler(0, -90, 0); // Set the rotation of the enemy
        Instantiate(_enemyPrefabs[animalIndex], spawnPosTop, _enemyPrefabs[animalIndex].transform.rotation); // Instantiate the enemy at the spawn position
        Instantiate(_enemyPrefabs[animalIndex], spawnPosLeft, _enemyPrefabs[animalIndex].transform.rotation * spawnRotationLeft); // Instantiate the enemy at the spawn position
        Instantiate(_enemyPrefabs[animalIndex], spawnPosRight, _enemyPrefabs[animalIndex].transform.rotation * spawnRotationRight); // Instantiate the enemy at the spawn position
        
    }
}
