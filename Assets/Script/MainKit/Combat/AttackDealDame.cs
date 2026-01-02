using UnityEngine;

public class AttackDealDame : MonoBehaviour
{
    [SerializeField] Collider2D myCollider;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == myCollider) { return; }
        if (other.CompareTag("Player"))
        {
            // Debug.Log(other.name);
            Health health = other.GetComponent<Health>();
            health.DealsDame(10);
        }
    }
}
