using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLaunch : MonoBehaviour {

    GameObject rocketPrefab;
    GameObject currentRocket;

    public int launchAngle;
    public float launchForce;
    public float burnTime;
    Vector2 mouseDir;

    bool needANewRocket = false;

	void Update () {

        // Press enter to spawn a new rocket if there isn't one already
        if (needANewRocket && Input.GetButtonDown("Enter"))
        {
            SpawnRocket();
        }

        // Press spacebar to launch rocket if there is one
        if (!needANewRocket && Input.GetButtonDown("Jump"))
        {
            LaunchRocket();
        }
	}

    void SpawnRocket()
    {
        currentRocket = Instantiate(rocketPrefab, this.transform);
    }

    void LaunchRocket()
    {

    }

}
