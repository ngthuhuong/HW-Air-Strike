using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Vector3 targetPosition;
    public bool hasStopped = false;

    private float moveSpeed = 4f;

    void Update()
    {
        if (!hasStopped)
        {
            // Di chuyển tới targetPosition
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Kiểm tra nếu đến nơi thì dừng lại
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                hasStopped = true;
                this.enabled = false; // Tắt Update để tiết kiệm hiệu năng
            }
        }
    }
}