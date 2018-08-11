using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchControls : MonoBehaviour {

    [HideInInspector]
    public float launchVelocity;
    [HideInInspector]
    public float launchAngle;




    private void Update()
    {

        // Check if the thruster is on 
        var emitter = booster.emission;
        if (thrust > 0.0f)
        {
            emitter.enabled = true;

        }
        else
        {
            emitter.enabled = false;
        }
    }

}
