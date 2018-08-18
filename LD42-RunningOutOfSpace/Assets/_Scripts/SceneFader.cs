using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve fadeCurve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
