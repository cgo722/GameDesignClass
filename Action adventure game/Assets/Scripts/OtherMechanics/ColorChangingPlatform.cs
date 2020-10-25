using System.Collections;
using UnityEngine;

public class ColorChangingPlatform : MonoBehaviour
{
    public Color ogColor;
    public Color color1;
    public Color color2;

    private Renderer renderer;

    public int waitTime;

    private WaitForSeconds wfs;

    private void Start()
    {
        wfs = new WaitForSeconds(waitTime);
        renderer = GetComponent<Renderer>();
        renderer.material.color = ogColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (renderer.material.color == ogColor)
        {
            renderer.material.color = color1;
        }
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        renderer.material.color = color2;
        yield return wfs;
        renderer.material.color = ogColor;
    }
}
