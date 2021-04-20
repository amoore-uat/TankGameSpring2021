using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    [Header("Movement speeds")]
    public float moveSpeed = 3f;
    public float turnSpeed = 30f;

    [Header("Cannon Data")]
    public int cannonBallDamage = 1;
    //[Space(20)]
    public float fireRate = 2f;

    [Header("Respawn Data")]
    public int lives = 3;
    public float respawnTime = 3f;
}
