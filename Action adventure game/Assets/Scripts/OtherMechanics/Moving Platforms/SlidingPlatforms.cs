using UnityEngine;

public class SlidingPlatforms : MonoBehaviour
{
    public Vector3Data position1;
    public Vector3Data position2;

    private void Update()
    {
        transform.position = Vector3.Lerp(position1.value, position2.value, Mathf.PingPong(Time.time, 1));
    }
}