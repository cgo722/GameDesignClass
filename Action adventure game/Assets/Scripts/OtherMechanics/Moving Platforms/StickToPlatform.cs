using System;
using System.Collections;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerScale;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            player.transform.parent = null;
        }
    }
}
