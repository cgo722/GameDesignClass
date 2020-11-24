using System;
using System.Collections;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    public float waitTime;
    private WaitForSeconds wfs;

    private void Start()
    {
        wfs = new WaitForSeconds(waitTime);
    }

    private IEnumerator StickToGround()
    {
        offset = player.transform.position - transform.position;
        player.transform.position = transform.position + offset;
        yield return wfs;
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StickToGround());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(StickToGround());
    }
}
