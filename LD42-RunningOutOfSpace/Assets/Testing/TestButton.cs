using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour {

    public LaunchPad lPad;
    public float burnTime;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 256, 30), "Launch the rocket for 2 seconds"))
        {
            lPad.LaunchRocket(burnTime);
        }
    }

}
