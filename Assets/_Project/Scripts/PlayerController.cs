using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private float moveSpeed = 7f; // Tốc độ di chuyển của player
    [SerializeField]
    public HealthController healthController;

    private int CurrentHealth => healthController.CurrentHealth;
    private bool isDead = false;
    // Update is called once per frame
    void Update()
    {
        
        if (isDead) return;
        if (Input.GetMouseButton(0)) // 0 là chuột trái
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
        if (CurrentHealth == 0)
        {
            PlayerDie();
        }
    }

    #region Public Methods

    

    #endregion
    
    #region Private Methods
    private void PlayerDie()
    {
        if (isDead) return; // Ensure PlayerDie is only called once
        isDead = true;
        Debug.Log("Player has died.");
        MMEventManager.TriggerEvent(new EGameOver());
    }

    #endregion
}
