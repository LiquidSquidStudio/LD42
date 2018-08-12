using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    int nSatellites;
    int highScore;
    public Text satCount;
    public Text highScoreText;

    void Start ()
    {
        UpdateText();
	}

	void Update ()
    {
        UpdateText();
        UpdateHighScore();
	}

    void UpdateHighScore()
    {
        if (nSatellites > highScore)
        {
            highScore = nSatellites;
        }
    }

    void UpdateText()
    {
        satCount.text = "There are " + CountSatellites() + " Satellites";
        highScoreText.text = "High Score: " + highScore;
    }

    int CountSatellites()
    {
        var sats = GameObject.FindGameObjectsWithTag("Satellite");
        nSatellites = sats.Length;

        return nSatellites;
    }
}
