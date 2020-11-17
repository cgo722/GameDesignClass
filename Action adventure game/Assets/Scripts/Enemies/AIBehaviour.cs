using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public float waitTime;
    private WaitForFixedUpdate wffu;
    private WaitForSeconds wfs;
    public BoolData playerDead;

    public IntData enemyCount;

    public Vector3Data playerLocation;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wfs = new WaitForSeconds(waitTime);
        agent.isStopped = false;
    }

    private void Update()
    {
       if (playerDead.value == false && agent.isStopped == false)
       {
             agent.destination = playerLocation.value;
       }

       if(playerDead.value == false && agent.isStopped == true)
        {
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Chasing()
    {
        yield return wfs;
        agent.isStopped = true;
    }
    private IEnumerator Destroy()
    {
        yield return wfs;
        Destroy(gameObject);
        enemyCount.value--;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            enemyCount.value--;
        }
    }
}
