using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    public int attackDamage = 5;
    public float attackRange = 1.5f;
    

    public int AttackDamage
    {
        get => attackDamage;
        set => attackDamage = value;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagConst.TagPlayer))
        {
            HealthController targetHealth = other.GetComponent<HealthController>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(attackDamage);
            }
        }
    }
}