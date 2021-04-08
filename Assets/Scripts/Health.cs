﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class Health : MonoBehaviour
{
    private TankData data;
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

    private void Start()
    {
        data = GetComponent<TankData>();
    }

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
        data.lives -= 1;
        // Check for actual game-over.
        if (GameManager.Instance.isMultiplayer)
        {
            int livesRemaining =
                GameManager.Instance.Players[0].GetComponent<TankData>().lives +
                GameManager.Instance.Players[1].GetComponent<TankData>().lives;
            if (livesRemaining <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (data.lives <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
        
        IKillable[] killables = GetComponentsInChildren<IKillable>();

        foreach (IKillable killable in killables)
        {
            killable.OnKilled(attackData);
        }
        if (data.lives > 0)
        {

            IRespawnable[] respawnables = GetComponentsInChildren<IRespawnable>();

            foreach (IRespawnable respawnable in respawnables)
            {
                respawnable.OnRespawn();
            }
        }
    }
}
