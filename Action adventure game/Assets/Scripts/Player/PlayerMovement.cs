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
    public float explosionForce;

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

        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCountMax = 0;
            rb.angularDrag = 1000f;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 direction = collision.transform.position - transform.position;

            rb.AddForce(transform.up * explosionForce, ForceMode.Impulse);
            rb.AddForce((-direction.normalized * 0.5f) * explosionForce, ForceMode.Impulse);

        }
    }

}
