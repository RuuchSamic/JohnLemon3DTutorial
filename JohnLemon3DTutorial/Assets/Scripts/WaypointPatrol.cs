using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    public Transform playerLocation;
    public Observer observeScript;
    private int npcState;

    private int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
        navMeshAgent.speed = 1.25f;
        npcState = observeScript.GetState();
    }

    void Update()
    {
        npcState = observeScript.GetState();
        if (npcState == 0)
        {
            if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
        }
        else if (npcState == 1)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(playerLocation.position);
        }
        else if (npcState == 2)
        {
            navMeshAgent.isStopped = true;
            Vector3 relativePos = playerLocation.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
        }
    }
}
