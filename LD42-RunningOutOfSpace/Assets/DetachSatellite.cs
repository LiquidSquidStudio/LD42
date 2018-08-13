using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DetachSatellite : MonoBehaviour {

    Rigidbody2D rb;
    Rigidbody2D satRb;
    Collider2D satC;
    SpriteRenderer rocket;
    Vector2 currentVelocity;

    public GameObject satellitePrefab;
    public Transform spawnPoint;
    public GameObject[] rocketParts;

    public float deceleration;
    public float forceBump;
    public float bumpTime;

    bool runTimer;
    float timer;

    public Image SatelliteIcon;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rocket = GetComponent<SpriteRenderer>();

        timer = 0f;
        runTimer = false;
    }

    public void BlowUpRocket()
    {
        currentVelocity = rb.velocity;

        foreach(GameObject part in rocketParts)
        {
            GameObject rPart = Instantiate(part, this.transform);
            Rigidbody2D rbPart = rPart.GetComponent<Rigidbody2D>();
            rbPart.velocity += (new Vector2(Random.Range(-forceBump, forceBump), Random.Range(-forceBump, forceBump)));
        }

        rocket.enabled = false;
    }

    public void LaunchSatellite()
    {
        GameObject sat = Instantiate(satellitePrefab, spawnPoint);

        // After detachment going to run a little timer that will push the satellite away from the rocket for a time. Possibly also enable/disable collider...
        satRb = sat.GetComponent<Rigidbody2D>();
        timer = 0;
        runTimer = true;

        satC = sat.GetComponent<Collider2D>();
        satC.enabled = false;

        if (SatelliteIcon != null)
        {
            StartCoroutine(MoveIconUpAndDown(SatelliteIcon));
        }
    }

    private void Update()
    {
        if (runTimer)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
    }

    private void FixedUpdate()
    {
        if (!satRb)
            return;

        if (timer < bumpTime)
        {
            satC.enabled = false;
            //Vector2 dir = currentVelocity.normalized;
            //Debug.Log(dir*forceBump);
            //satRb.AddForce(forceBump * dir);
        }
        else
        {
            satC.enabled = true;
            runTimer = false;
        }
    }

    private IEnumerator MoveIconUpAndDown(Image icon)
    {
        // move up
        var originalPos = icon.transform.localPosition;
        var newPos = originalPos + new Vector3(0.0f, 50.0f, 0.0f);

        icon.transform.localPosition = newPos;

        yield return new WaitForSecondsRealtime(0.5f);

        icon.transform.localPosition = originalPos;

    }
}
