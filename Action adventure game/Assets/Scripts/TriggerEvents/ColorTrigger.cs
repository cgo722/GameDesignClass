using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorTrigger : MonoBehaviour
{

    private MeshRenderer meshR;
    public Color newColor;
    public Color ogColor;
    

    // Start is called before the first frame update
    void Start()
    {
        meshR = GetComponent<MeshRenderer>();
        meshR.material.color = ogColor;
    }


    private void OnTriggerEnter(Collider other)
    {
        meshR.material.color = newColor;
        
    }

    private void OnTriggerExit(Collider other)
    {
        meshR.material.color = ogColor;
        
    }
}
