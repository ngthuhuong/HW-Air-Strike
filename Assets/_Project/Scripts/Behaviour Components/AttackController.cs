using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    public int attackDamage = 10;
    public float attackRange = 1.5f;
    
    public string targetTag = "Player"; // Tag of the target to attack

    public int AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(targetTag))
        {
            HealthController targetHealth = other.GetComponent<HealthController>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(attackDamage);
            }
        }
    }
}