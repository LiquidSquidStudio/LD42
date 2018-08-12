using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachSatellite : MonoBehaviour {

    Rigidbody2D rb;

    public GameObject satellitePrefab;
    public Transform spawnPoint;

    public float deceleration;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(satellitePrefab, spawnPoint);

            rb.AddForce(new Vector2(deceleration, 0));
        }
	}
}
