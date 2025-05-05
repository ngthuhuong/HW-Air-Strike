using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public void MoveTo(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}