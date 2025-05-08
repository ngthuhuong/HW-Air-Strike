using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private float moveSpeed = 4f;
    [SerializeField]

    void Update()
    {
        // Move the enemy downward
        transform.position +=  moveSpeed * Time.deltaTime * Vector3.down ;

        // Optional: Destroy the enemy if it goes out of bounds
        if (transform.position.y < -10f) // Adjust the boundary as needed
        {
            Destroy(gameObject);
        }
    }
    
    
    #region Private Methods
private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagConst.TagPlayer))
        {
            Debug.Log("Collision w"+ other.name);
            Die();
        }
    }

    #endregion

    #region Public Methods

    public void Die()
    {
        Destroy(gameObject);
    }
    

    #endregion
}