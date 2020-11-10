using UnityEngine;

public class SlidingPlatforms : MonoBehaviour
{
    public Vector3 position1;
    public Vector3 position2;

    public float speed = 1f;
    public float holdTime = 1f;

    private void Update()
    {
        transform.position = Vector3.Lerp(position1, position2, Mathf.PingPong(Time.time * speed, holdTime));
    }
}