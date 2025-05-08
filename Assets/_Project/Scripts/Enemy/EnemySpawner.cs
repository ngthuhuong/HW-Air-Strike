using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1f; // Time interval between spawns

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Spawn enemy at a random position
            float spawnX = Random.Range(-3f, 3f);
            Vector3 spawnPos = new Vector3(spawnX, 5f, 0f);

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}