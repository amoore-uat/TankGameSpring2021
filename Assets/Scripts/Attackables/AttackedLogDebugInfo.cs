﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedLogDebugInfo : MonoBehaviour, IAttackable
{
    public void OnAttacked(Attack attack)
    {
        Debug.Log(gameObject.name + " was Attacked by " + attack.attacker + " for " + attack.attackDamage + " damage");
    }
}
