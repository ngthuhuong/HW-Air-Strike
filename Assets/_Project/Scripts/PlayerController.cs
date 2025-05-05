using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private float moveSpeed = 5f; // Tốc độ di chuyển của player
    // Start is called before the first frame update
    public GameOverGUI gameOverGUI;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with Enemy! Game Over.");
            
            // Call the Game Over UI
            gameOverGUI.GameOver();
            
            // Destroy player object
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // 0 là chuột trái
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
    }
}
