using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletForce : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        var forceDirection = new Vector3(0, 0, force);
        rb.AddRelativeForce(forceDirection);
    }
}
