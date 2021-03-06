﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject attacker;
    public int attackDamage;

    private void OnCollisionEnter(Collision collision)
    {
        Attack attackData = new Attack(attacker, attackDamage);

        IAttackable[] attackables = collision.gameObject.GetComponents<IAttackable>();

        foreach (IAttackable attackable in attackables)
        {
            attackable.OnAttacked(attackData);
        }

        //collision.gameObject.SendMessage("TakeDamage", attackData, SendMessageOptions.DontRequireReceiver);

        // Destroy our cannonball when it runs into another object.
        Destroy(this.gameObject);
    }

}
