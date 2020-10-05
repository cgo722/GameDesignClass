using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{

    public float jumpHeight;

    public int jumpCountMax = 0;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCountMax < 2)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            jumpCountMax++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCountMax = 0;            
        }
    }

}
