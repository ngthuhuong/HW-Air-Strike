using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRate = 1.0f; 
    private float spawnAreaWidth = 3.0f;
    [SerializeField]
    public GameObject enemyPrefab;
    
    void Start()
    {
        StartCoroutine(CoroutineSpawnEnemy());
    }
    IEnumerator CoroutineSpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        float spawnX = Random.Range(-spawnAreaWidth, spawnAreaWidth);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    
}
