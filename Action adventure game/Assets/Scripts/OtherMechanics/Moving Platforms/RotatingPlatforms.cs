using UnityEngine;

public class RotatingPlatforms : MonoBehaviour
{
    public Transform position1;
    public Transform position2;

    public float speed = 1f;
    public float holdTime = 1f;

    private void Update()
    {
        var t = Mathf.PingPong(Time.time * speed, holdTime);
        transform.rotation = Quaternion.Slerp(position1.rotation, position2.rotation, t);
        transform.position = Vector3.Lerp(position1.position, position2.position, t);
    }
}