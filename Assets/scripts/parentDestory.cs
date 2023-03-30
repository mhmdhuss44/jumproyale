using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentDestory : MonoBehaviour
{

    [SerializeField] private int maxHealth = 2;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Destroy the enemy object when it runs out of health
        Destroy(transform.parent.gameObject);
    }
}