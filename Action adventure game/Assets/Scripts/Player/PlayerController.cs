﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController: MonoBehaviour
{

    public float moveSpeed, rotateSpeed, runSpeed, runRotateSpeed, jumpHeight, explosionForce, stationaryExplosionForce, webForce;

    public bool isGrounded;

    private int jumpCountMax = 0;

    private Rigidbody rb;


    public BoolData dead;
    public Vector3Data spawnVector3;

    public GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dead.value = false;
        spawnVector3.value = player.transform.position;
    }


    void Update()
    {
        

        var vInput = Input.GetAxis("Vertical");
        var hInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (isGrounded == true)
            {
                transform.Translate(Vector3.forward * vInput * runSpeed * Time.deltaTime);
                transform.Rotate(0, hInput * runRotateSpeed, 0);
            }
        }
        else
        {
            if (isGrounded == true)
            {
                transform.Translate(Vector3.forward * vInput * moveSpeed * Time.deltaTime);
                transform.Rotate(0, hInput * rotateSpeed, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCountMax < 2)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            jumpCountMax++;
        }
    }

    private IEnumerator DeathAndRespawn()
    {
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.transform.position = spawnVector3.value;
        isGrounded = true;
        dead.value = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCountMax = 0;
            rb.angularDrag = 1000f;
        }else { isGrounded = false; }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 direction = collision.transform.position - transform.position;

            rb.AddForce(transform.up * explosionForce, ForceMode.Impulse);
            rb.AddForce(-direction.normalized * explosionForce, ForceMode.Impulse);

        }

        if (collision.gameObject.CompareTag("StationaryEnemy"))
        {
            Vector3 direction = collision.transform.position - transform.position;

            rb.AddForce(transform.up * stationaryExplosionForce, ForceMode.Impulse);
            rb.AddForce(-direction.normalized * stationaryExplosionForce, ForceMode.Impulse);

        }

        if (collision.gameObject.CompareTag("SpiderWeb"))
        {
            isGrounded = true;
            rb.AddForce(transform.up * webForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            dead.value = true;
            StartCoroutine(DeathAndRespawn());
        }
    }
}
