using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, triggerStayEvent, triggerExitEvent;
    public float delayTime = 0.01f;
    private WaitForSeconds waitObj;

    private void Start()
    {
        waitObj = new WaitForSeconds(delayTime);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        yield return waitObj;
        triggerEnterEvent.Invoke();
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        yield return waitObj;
        triggerStayEvent.Invoke();
    }


    private IEnumerator OnTriggerExit(Collider other)
    {
        yield return waitObj;
        triggerExitEvent.Invoke();
    }
}