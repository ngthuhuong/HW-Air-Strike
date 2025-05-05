using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int rows = 5;
    public int cols = 4;
    public float spacingX = 1.5f;
    public float spacingY = 1.2f;

    private void Start()
    {
        StartCoroutine(SpawnFormation());
    }

    private IEnumerator SpawnFormation()
    {
        // Tâm đội hình
        Vector3 formationCenter = transform.position + new Vector3(0, -rows * spacingY / 2f, 0);

        for (int row = rows - 1; row >= 0; row--) // từ hàng dưới lên
        {
            List<GameObject> currentRowEnemies = new List<GameObject>();

            for (int col = 0; col < cols; col++)
            {
                // Tính vị trí target
                Vector3 offset = new Vector3((col - (cols - 1) / 2f) * spacingX, -row * spacingY, 0);
                Vector3 targetPos = formationCenter + offset;

                // Vị trí spawn ngẫu nhiên trên trục X, tại Y = 5
                float spawnX = Random.Range(-3f, 3f);
                Vector3 spawnPos = new Vector3(spawnX, 5f, 0f);

                GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                enemy.GetComponent<EnemyManager>().targetPosition = targetPos;
                currentRowEnemies.Add(enemy);
            }

            // Chờ cho đến khi tất cả enemy của hàng hiện tại đã dừng lại
            yield return new WaitUntil(() =>
            {
                foreach (GameObject enemy in currentRowEnemies)
                {
                    if (enemy != null && !enemy.GetComponent<EnemyManager>().hasStopped)
                        return false;
                }
                return true;
            });

            yield return new WaitForSeconds(0.3f); 
        }
    }
}