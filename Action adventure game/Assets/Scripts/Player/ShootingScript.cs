using System.Collections;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3Data firePoint;



    private void Update()
    {
        firePoint.value = transform.position;
        Shooting();
    }

    public void Shooting()
    {
        var location = firePoint.value;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(prefab, location, transform.rotation);
        }
    }
}
