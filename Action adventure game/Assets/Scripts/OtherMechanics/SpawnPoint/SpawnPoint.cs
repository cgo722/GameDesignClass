using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3Data spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawn.value = transform.position;
        }
    }

    
}
