using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 10;
    [SerializeField] private int currentHealth; 

    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = Mathf.Clamp(value, 0, maxHealth);
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    #region Public Methods

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            return;
        }
    }

    public void SetHealth()
    {
        CurrentHealth = maxHealth;
    }

    #endregion
}