using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public void PlayGame()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        sceneFader.FadeTo(nextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
