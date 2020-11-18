using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject ui;
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync("Level design");
    }

    public void LoadHowTo()
    {
        SceneManager.LoadSceneAsync("HowTo");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
        Debug.Log("Change to Main Menu");
    }

    public void ResumeGame()
    {
        ui.SetActive(false);
        Time.timeScale = 1;

    }
}
