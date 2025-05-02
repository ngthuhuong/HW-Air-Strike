using System.Collections;
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
        // Thẳng lên
        SpawnSingleBullet(Vector2.up);

        // Lệch trái 30 độ
        SpawnSingleBullet(Quaternion.Euler(0, 0, -15) * Vector2.up);

        // Lệch phải 30 độ
        SpawnSingleBullet(Quaternion.Euler(0, 0, 15) * Vector2.up);
    }

    private void SpawnSingleBullet(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle - 90); // -90 nếu đạn ban đầu quay lên

        GameObject bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, rotation);
        bullet.GetComponent<BulletManager>().SetDirection(direction);
    }

}