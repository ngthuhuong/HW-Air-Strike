using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject BulletPrefab;
    public Transform BulletSpawnPoint;
    public float spawnRate = 0.5f;
    void Start()
    {
        StartCoroutine(SpawnBulletRoutine());
    }
    private IEnumerator SpawnBulletRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
    }
    void Update()
    {
        
    }
}
