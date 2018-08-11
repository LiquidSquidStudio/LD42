using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour {

    public AudioController aC;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 256, 30), "Go to next audio clip"))
        {
            aC.NextClip(1);
        }
    }

}
