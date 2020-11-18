using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public float chaseTime, stopTime;
    private WaitForFixedUpdate wffu;
    private WaitForSeconds wfs1, wfs2;
    public BoolData playerDead;

    public IntData enemyCount;

    public Vector3Data playerLocation;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wfs1 = new WaitForSeconds(chaseTime);
        wfs2 = new WaitForSeconds(stopTime);
        agent.isStopped = false;
        StartCoroutine(Chasing());
    }

    private void Update()
    {
        agent.destination = playerLocation.value;

        if (playerDead.value == false && agent.isStopped == true)
        {
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Chasing()
    {
        while (playerDead.value == false && agent.isStopped == false)
        {
            yield return wfs1;
            agent.isStopped = true;
        }
    }
    private IEnumerator Destroy()
    {
        Debug.Log(agent.isStopped);
        yield return wfs2;
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
