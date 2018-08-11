using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour {

    //public enum controls { Keyboard, Mouse };
    //public controls controlScheme = controls.Keyboard;

    public GameObject rocketPrefab;

    public float launchVelocity;
    public float launchAngle;

	// Use this for initialization
	void Start ()
    {
        SpawnRocket();		
	}
	
    void SpawnRocket()
    {
        Instantiate(rocketPrefab, transform);
    }

    void PointRocket()
    {

        Vector2 aimPosition = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

        Vector2 desiredDir = aimPosition - (Vector2)transform.position;

    }

    // Update is called once per frame
    void Update ()
    {
        PointRocket();
	}
}
