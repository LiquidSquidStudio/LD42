using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Satalite : MonoBehaviour {

	public float initialForce = 1000.0f;
	public float mass = 1.0f;
	test_Planet planet;
	float radius;
	Rigidbody2D rb;
	float dragFactor = 0.01f;
	float timeToCrash = 0.5f;
	float timer = 0.0f;
	public GameObject explosion;


	// Use this for initialization
	void Start () 
	{
	
		// Get a reference to the planet 
		planet = FindObjectOfType<test_Planet> ().GetComponent<test_Planet>(); 

		// Find out the starting radius
		radius = (planet.transform.position - transform.position).magnitude;

		// Get a reference to a rigid body 
		rb = GetComponent<Rigidbody2D>();

		// Find the angle of the statlite to the planet
		float angle = Mathf.Atan2(transform.position.y, transform.position.x);

		// Find the direction of the tangential force based on the starting position ( Might not be required if we use rockets to accelerate the satalites up there)
		Vector2 forceDir = new Vector2(-transform.position.y/Mathf.Tan(90*Mathf.Deg2Rad - angle), radius*Mathf.Sin(angle));

		// Add the initial force to make the satalite orbit
		rb.AddForce(forceDir.normalized * initialForce);

	}


	// Update the game logic
	void Update()
	{
		
	}


	// Update the physics
	void FixedUpdate()
	{

		// calculate the distance
		float distance = (planet.transform.position - transform.position).sqrMagnitude;

		// Apply a current force towards the planet f = mv/r^2
		rb.AddForce ((planet.transform.position - transform.position).normalized * planet.gravity * mass / distance);

		// Apply the current drag factor
		rb.velocity -= rb.velocity*dragFactor*Time.deltaTime;

	}

	// Need to test for collision with planet and other statalites
	void OnTriggerEnter2D(Collider2D other)
	{

		// Check if it's the planet and if so destroy this Satelite (Need to make this onto a tag)
		if (other.gameObject.name == "testPlanet")
		{
			// increase the drag
			mass *= 3.0f;
			// Start the crash procedure
			StartCoroutine (Crash());
		}

		// To be completed
		if (other.gameObject.name == "testAtmosphere")
		{

		}

		// To be completed
		if (other.gameObject.tag == "Satalite")
		{

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
			
		// Spawn a wee explosion (which will destoy itself after some time)
		GameObject explode = Instantiate (explosion).gameObject;

		// remove the parent
		explode.transform.parent = null;

		// Set the position
		explode.transform.position = gameObject.transform.position;

		// Reset the size
		explode.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				
		// Destroy this 
		Destroy (this.gameObject);
	
	}
		
}
