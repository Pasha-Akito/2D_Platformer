using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int startHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = startHealth;
    }

    public void Takedamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt animation
        // Place holder

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Debug.Log("Enemy died");

        //Die animation
        // Place holder

        //Disable the enemy
        Destroy(gameObject);
    }
}
