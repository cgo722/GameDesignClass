using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject ui;


    private void Start()
    {
        ui.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        ui.SetActive(true);
        Time.timeScale = 0;
    }
}
