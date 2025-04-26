using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float moveSpeed = 10f;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        gameObject.transform.Translate(( moveSpeed * Time.deltaTime)*Vector2.up );
        checkOutScreen();
    }

    private void checkOutScreen()
    {
        if(gameObject.transform.position.y > 5.25f ||  gameObject.transform.position.x > 3f || gameObject.transform.position.x < -3f)
        {
            Destroy(gameObject);
        }
    }
}
