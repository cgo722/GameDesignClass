using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float rotateSpeed;
    public float runSpeed;
    public float runRotateSpeed;
    public float jumpHeight;

    private int jumpCountMax = 0;

    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        var vInput = Input.GetAxis("Vertical");
        var hInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * vInput * runSpeed * Time.deltaTime);
            transform.Rotate(0, hInput * runRotateSpeed, 0);
        }
        else
        {
            transform.Translate(Vector3.forward * vInput * moveSpeed * Time.deltaTime);
            transform.Rotate(0, hInput * rotateSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCountMax < 2)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            jumpCountMax++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var explosionForce = 5000;

        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCountMax = 0;            
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.AddForce(force * explosionForce, ForceMode.Impulse);
        }
    }

}
