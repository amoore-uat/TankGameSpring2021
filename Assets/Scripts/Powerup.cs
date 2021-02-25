using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Powerup
{
    public float speedModifier = 0f;
    public int healthModifier = 0;
    public int maxHealthModifier = 0;
    public float fireRateModifier = 0f; // Adjusts the cooldown timer for shooting. Negative number means faster.

    public float duration = 1f;
    public bool isPermanent = false;

    public void OnActivate(TankData targetData, Health targetHealth)
    {
        targetData.moveSpeed += speedModifier;
        targetData.fireRate += fireRateModifier;
        targetHealth.maxHealth += maxHealthModifier;
        targetHealth.CurrentHealth += healthModifier;

    }

    public void OnDeactivate(TankData targetData, Health targetHealth)
    {
        targetData.moveSpeed -= speedModifier;
        targetData.fireRate -= fireRateModifier;
        // If you set Health up as a non-monobehavior class
        //target.tankHealth.maxHealth -= maxHealthModifier;
        targetHealth.maxHealth -= maxHealthModifier;
        targetHealth.CurrentHealth -= healthModifier;
    }
}
