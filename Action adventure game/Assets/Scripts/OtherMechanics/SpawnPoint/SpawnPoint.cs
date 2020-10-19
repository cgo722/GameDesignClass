using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3Data spawn;

    private void Start()
    {
        spawn.value = transform.position;
    }
}
