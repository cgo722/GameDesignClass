using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    private WaitForFixedUpdate wffu;
    private WaitForSeconds wfs;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        agent.destination = player.position;
        
    }
}
