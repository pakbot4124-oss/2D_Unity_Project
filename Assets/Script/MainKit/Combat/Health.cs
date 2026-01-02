using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;

    public event Action OnDeath;
    public event Action OnHurt;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DealsDame(int dame)
    {
        currentHealth -= dame;
        OnHurt?.Invoke();
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
