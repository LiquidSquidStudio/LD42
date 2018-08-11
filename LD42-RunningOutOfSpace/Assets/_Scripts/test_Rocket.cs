using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Rocket : MonoBehaviour {

	Rigidbody2D rb;

	public float turningTorque = 10.0f;
	public float thrustForce = 10.0f;

	//Keyboard control variables 
	float turning = 0.0f;
	float thrust = 0.0f;

	public float fuel;

	float mass = 1.0f;
	float dragFactor = 0.01f;

	ParticleSystem booster;

	test_Planet planet;

	// Use this for initialization
	void Start () 
	{

		// Get a reference to the rigidbody
		rb = GetComponent<Rigidbody2D> ();

		// Get a reference to the planet 
		planet = FindObjectOfType<test_Planet> ().GetComponent<test_Planet>(); 

		// Get a reference to the rocket booster
		booster = GetComponentInChildren<ParticleSystem>();

		// Start Off
		var emitter = booster.emission;
		emitter.enabled = false;
		
	}

	// Update is called once per frame
	void Update () 
	{


		// Keyboard Control Scheme
		turning = Input.GetAxis("Horizontal") * -turningTorque;

		// Force to apply 
		thrust = Input.GetAxis("Vertical") * thrustForce;

		var emitter = booster.emission;

		// Check if the thruster is on 
		if (Input.GetAxis ("Vertical") > 0.0f)
		{
			emitter.enabled = true;
		} else
		{
			emitter.enabled = false;
		}
			
		
	}


	// Update the physics
	void FixedUpdate()
	{

		// Apply gravity
		// calculate the distance
		float distance = (planet.transform.position - transform.position).sqrMagnitude;

		// Apply a current force towards the planet f = mv/r^2
		rb.AddForce ((planet.transform.position - transform.position).normalized * planet.gravity * mass / distance);

		// Apply the current drag factor
		rb.velocity -= rb.velocity*dragFactor*Time.deltaTime;


		// Apply Turning Torque
		rb.AddTorque(turning);

		// Apply Rocket Torque
		rb.AddForce (thrust * transform.up);

	}

	void OnCollisionEnter2D(Collision2D other)
	{

	}

}
