using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueBoss : MonoBehaviour
{
    public IntData health;

    public BoolData playerProjectile;

    public BoolData dead;

    private void Start()
    {
        health.value = 3;
    }

    private void Update()
    {
        if(health.value <= 0)
        {
            dead.value = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && playerProjectile == true)
        {
            health.value--;
        }
    }
}
