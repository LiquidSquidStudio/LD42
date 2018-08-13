using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class LaunchPad : MonoBehaviour {

    //public enum controls { Keyboard, Mouse };
    //public controls controlScheme = controls.Keyboard;

    public GameObject rocketPrefab;

    public int rocketBurnTime;
    public int launchAngle;
    public bool isLaunchable;

    GameObject currentRocket;
    public DetachSatellite satControl;

    public Image LaunchIcon;

	// Use this for initialization
	void Awake ()
    {
        SpawnRocket();
        if (LaunchIcon == null)
        {
            throw new NullReferenceException("Need to wire up Launch icon and satellite icon to the script 'LaunchPad' instance bro.");
        }
    }

    void SpawnRocket()
    {
        currentRocket = Instantiate(rocketPrefab, transform);
        isLaunchable = true;

        satControl = currentRocket.GetComponent<DetachSatellite>();
        satControl.enabled = false;
    }

    void NeedANewRocket()
    {
        if (!isLaunchable && Input.GetButtonDown("Fire1"))
        {
            satControl.BlowUpRocket();
            satControl.LaunchSatellite();
            SpawnRocket();
        }
    }

    public void LaunchRocket(float burnTime)
    {
        LaunchControls rocketControls = currentRocket.GetComponent<LaunchControls>();
        rocketControls.LaunchRocket(burnTime);
        isLaunchable = false;
        satControl.enabled = true;

        // move icon
        StartCoroutine(MoveIconUpAndDown(LaunchIcon));
    }

    private IEnumerator MoveIconUpAndDown(Image icon)
    {
        // move up
        var originalPos = icon.transform.localPosition;
        var newPos = originalPos + new Vector3(0.0f, 100.0f, 0.0f);

        icon.transform.localPosition = newPos;

        yield return new WaitForSecondsRealtime(1.0f);

        icon.transform.localPosition = originalPos;

    }

    // Update is called once per frame
    void Update ()
    {
        NeedANewRocket();

        if (!isLaunchable)
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            LaunchRocket(rocketBurnTime);
        }

        //PointRocket();

        //void PointRocket()
        //{
        //    Vector2 aimPosition = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));

        //    Vector2 desiredDir = aimPosition - (Vector2)transform.position;
        //}
    }
}
