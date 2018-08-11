using System.Collections;
using UnityEngine;

public class SatelliteController : MonoBehaviour {

    Rigidbody2D rb;

    float dragFactor = 0.01f;
    float timeToCrash = 0.5f;
    float timer = 0.0f;

    public float initialForce = 1000.0f;
    public float mass = 1.0f;

    public GameObject explosion;

    // Sort references
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update the drag physics
    void FixedUpdate()
    {
        rb.velocity -= rb.velocity * dragFactor * Time.deltaTime;
    }

    // Need to test for collision with planet and other satellites
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if it's the planet and if so destroy this Satelite (Need to make this onto a tag)
        if (other.gameObject.name == "testPlanet")
        {
            // increase the drag
            mass *= 3.0f;
            // Start the crash procedure
            StartCoroutine(Crash());
        }

        if (other.gameObject.tag == "Satellite")
        {
            Explode();
        }
    }

    // If it's too close bring it in and crash
    IEnumerator Crash()
    {
        while (timer < timeToCrash)
        {
            timer += Time.deltaTime;
            transform.localScale *= ((timeToCrash - timer) / timeToCrash);
            yield return null;
        }

        Explode();
    }

    // Spawn a wee explosion (which will destoy itself after some time)
    void Explode()
    {
        GameObject explode = Instantiate(explosion).gameObject;

        // remove the parent
        explode.transform.parent = null;

        // Set the position
        explode.transform.position = gameObject.transform.position;

        // Reset the size
        explode.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Destroy this 
        Destroy(this.gameObject);
    }

}