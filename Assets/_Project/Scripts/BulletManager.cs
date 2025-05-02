using System.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Vector2 moveDirection = Vector2.up;

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        checkOutScreen();
    }

    private void checkOutScreen()
    {
        if (transform.position.y > 5.25f || transform.position.x > 3f || transform.position.x < -3f)
        {
            Destroy(gameObject);
        }
    }
}