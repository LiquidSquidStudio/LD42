using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void PlayGame()
    {
        string nextScene = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        sceneFader.FadeTo(nextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
