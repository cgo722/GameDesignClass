using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
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
}
