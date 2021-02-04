using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(TankShooter))]
[RequireComponent(typeof(TankMotor))]
public class SampleAIController1 : MonoBehaviour
{
    // TODO: We need a way to keep track of all the waypoints.
    public GameObject[] waypoints;
    // We need a way to keep track of the current waypoint.
    private int currentWaypoint = 1;

    private TankData data;
    private TankMotor motor;
    private TankShooter shooter;

    public enum LoopType { Stop, Loop, PingPong };
    public LoopType loopType = LoopType.Stop;

    public float closeEnough = 1f;

    private bool isLoopingForward = true;


    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        shooter = GetComponent<TankShooter>();
    }

    // Update is called once per frame
    void Update()
    {

        // if we're not rotated to face the waypoint, turn to face it.
        if (motor.RotateTowards(waypoints[currentWaypoint].transform.position, data.turnSpeed))
        {
            // Do nothing
        }
        // if we're facing the waypoint, move towards it.
        else
        {
            motor.Move(data.moveSpeed);
        }
        // If we've arrived at our waypoint, then go to the next one.
        if (loopType == LoopType.Stop)
        {
            if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
            {
                if (IsNotAtFinalWaypoint())
                {
                    currentWaypoint++;
                }
            }
        }
        else if (loopType == LoopType.Loop)
        {

            if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
            {
                if (IsNotAtFinalWaypoint())
                {
                    currentWaypoint++;
                }
                else
                {
                    currentWaypoint = 0;
                }
            }
        }
        else if (loopType == LoopType.PingPong)
        {
            if (isLoopingForward)
            {
                if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
                {
                    if (IsNotAtFinalWaypoint())
                    {
                        currentWaypoint++;
                    }
                    else
                    {
                        isLoopingForward = false;
                    }
                }
            }
            else
            {
                if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
                {
                    if (currentWaypoint > 0)
                    {
                        currentWaypoint--;
                    }
                    else
                    {
                        isLoopingForward = true;
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("[SampleAIController1] Unexepected LoopType");
        }
    }

    private bool IsNotAtFinalWaypoint()
    {
        return currentWaypoint < (waypoints.Length - 1);
    }
    
}
