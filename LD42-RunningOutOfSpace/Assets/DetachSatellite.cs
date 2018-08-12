using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachSatellite : MonoBehaviour {

    Rigidbody2D rb;
    SpriteRenderer rocket;

    public GameObject satellitePrefab;
    public Transform spawnPoint;
    public GameObject[] rocketParts;

    public float deceleration;
    public float velocityBump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rocket = GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            BlowUpRocket();
            LaunchSatellite();
        }
	}

    void BlowUpRocket()
    {
        Vector2 currentVelocity = rb.velocity;

        foreach(GameObject part in rocketParts)
        {
            GameObject rPart = Instantiate(part, this.transform);
            Rigidbody2D rbPart = rPart.GetComponent<Rigidbody2D>();
            rbPart.velocity += (new Vector2(Random.Range(-velocityBump, velocityBump), Random.Range(-velocityBump, velocityBump)));
        }

        rocket.enabled = false;
    }

    void LaunchSatellite()
    {
        Instantiate(satellitePrefab, spawnPoint);
    }
}
