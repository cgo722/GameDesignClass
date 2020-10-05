using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkAndRun: MonoBehaviour
{

    public float moveSpeed;
    public float rotateSpeed;
    public float runSpeed;
    public float runRotateSpeed;


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

    }

}
