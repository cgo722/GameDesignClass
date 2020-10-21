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
    public BoolData playerDead;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
       if (playerDead.value == false)
       {
             agent.destination = player.position;
       }
    }
}
