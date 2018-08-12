using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaunchPad : MonoBehaviour {

    //public enum controls { Keyboard, Mouse };
    //public controls controlScheme = controls.Keyboard;

    public GameObject rocketPrefab;

    public int rocketBurnTime;
    public int launchAngle;
    public bool isLaunchable;

    GameObject currentRocket;


	// Use this for initialization
	void Start ()
    {
        SpawnRocket();
    }
	
    void SpawnRocket()
    {
        currentRocket = Instantiate(rocketPrefab, transform);
        isLaunchable = true;

        // Added in an Event listener here to tell when we need another rocket because the old one is destroyed
        var needANewRocket = currentRocket.GetComponent<SelfDestruct>().rocketDestroyed;
        needANewRocket.RemoveListener(SpawnRocket);
        needANewRocket.AddListener(SpawnRocket);
    }

    //void PointRocket()
    //{
    //    Vector2 aimPosition = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

    //    Vector2 desiredDir = aimPosition - (Vector2)transform.position;
    //}

    public void LaunchRocket(float burnTime)
    {
        LaunchControls rocketControls = currentRocket.GetComponent<LaunchControls>();
        rocketControls.LaunchRocket(burnTime);
        isLaunchable = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isLaunchable)
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            LaunchRocket(rocketBurnTime);
        }

        //PointRocket();
	}
}
