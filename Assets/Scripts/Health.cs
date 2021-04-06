using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int currentHealth = 3;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            if (currentHealth <= 0)
            {
                // Die(attackData);
            }
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
    public int maxHealth = 5;

    public void TakeDamage(Attack attackData)
    {
        currentHealth -= attackData.attackDamage;

        // check to see if we died
        if (currentHealth <= 0)
        {
            Die(attackData);
        }
    }

    private void Die(Attack attackData)
    {
        IKillable[] killables = GetComponents<IKillable>();

        foreach (IKillable killable in killables)
        {
            killable.OnKilled(attackData);
        }
    }
}
