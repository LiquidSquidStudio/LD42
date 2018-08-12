using UnityEngine;

public class LaunchPad : MonoBehaviour {

    //public enum controls { Keyboard, Mouse };
    //public controls controlScheme = controls.Keyboard;

    public GameObject rocketPrefab;

    public int rocketBurnTime;
    public int launchAngle;
    public bool isLaunchable;

    GameObject currentRocket;
    public DetachSatellite satControl;

	// Use this for initialization
	void Awake ()
    {
        SpawnRocket();
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
