using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   private float moveSpeed = 5f;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate((moveSpeed * Time.deltaTime )*Vector2.down);
        checkOutScreen();
    }
    private void checkOutScreen()
    {
        if(gameObject.transform.position.y < -5.25f || gameObject.transform.position.x > 3f || gameObject.transform.position.x < -3f)
        {
            Destroy(gameObject);
        }
    }
}
