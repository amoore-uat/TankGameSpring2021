using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFSM : MonoBehaviour
{
    public enum EnemyPersonality { Guard, Cowardly };
    public EnemyPersonality personality = EnemyPersonality.Guard;

    public enum AIState { Chase, ChaseAndFire, CheckForFlee, Flee, Rest };
    public AIState aiState = AIState.Chase;
    private float health;
    private float maxHealth;

    public float stateExitTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (personality)
        {
            case EnemyPersonality.Guard:
                GuardFSM();
                break;
            case EnemyPersonality.Cowardly:
                CowardlyFSM();
                break;
            default:
                Debug.LogWarning("[SampleFSM] Unimplemented finite state machine");
                break;
        }
    }

    void GuardFSM()
    {
        switch (aiState)
        {
            case AIState.Chase:
                // Do behaviors
                Chase();
                // Check for transitions
                if (health < maxHealth * 0.5)
                {
                    ChangeState(AIState.CheckForFlee);
                }
                else if (PlayerIsInRange())
                {
                    ChangeState(AIState.ChaseAndFire);
                }
                break;
            case AIState.ChaseAndFire:
                // Do behaviors
                ChaseAndFire();
                // Check for transitions
                if (health < maxHealth * 0.5)
                {
                    ChangeState(AIState.CheckForFlee);
                }
                else if (!PlayerIsInRange())
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.CheckForFlee:
                break;
            case AIState.Flee:
                break;
            case AIState.Rest:
                break;
            default:
                Debug.LogWarning("[SampleFSM] State doesn't exist.");
                break;
        }
    }

    private void ChaseAndFire()
    {
        // TODO: Write this method
    }

    private bool PlayerIsInRange()
    {
        return true;
    }

    private void Chase()
    {
        // TODO: Write this method too
    }

    void CowardlyFSM()
    {
        // TODO: Write your own behaviors
    }

    void ChangeState(AIState newState)
    {
        aiState = newState;

        stateExitTime = Time.time;
    }
}
