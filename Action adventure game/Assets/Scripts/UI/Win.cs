using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject ui;

    private void Start()
    {
        ui.SetActive(false);
    }

    public void WinScreen()
    {
        ui.SetActive(true);
    }
}
