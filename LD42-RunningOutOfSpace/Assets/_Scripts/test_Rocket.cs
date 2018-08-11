using UnityEngine;

public class test_Rocket : MonoBehaviour {

	// A editor selector for controls
	public enum controls {Keyboard, Mouse};
	public controls controlScheme = controls.Keyboard;

  	Rigidbody2D rb;

	public float turningTorque = 10.0f;
	public float thrustForce = 10.0f;

	//Keyboard control variables 
	float turning = 0.0f;
	public float thrust = 0.0f;

	//public float fuel;

	ParticleSystem booster;

	test_Planet planet;

	void Awake() 
	{
        rb = GetComponent<Rigidbody2D>();
        // Get a reference to the rocket booster
        booster = GetComponentInChildren<ParticleSystem>();

		// Start Off
		var emitter = booster.emission;
		emitter.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (controlScheme == controls.Keyboard)
		{
			// Keyboard Control Scheme
			turning = Input.GetAxis ("Horizontal") * -turningTorque;

			// Force to apply 
			thrust = Input.GetAxis ("Vertical") * thrustForce;
		} else
		{
			// If the left button is pressed
			if (Input.GetMouseButton (0))
			{
				// Get the world point from the mouse position
				Vector2 aimPosition = (Vector2)Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f));

				// Get the vector to the desired positon 
				Vector2 desiredDir = aimPosition - (Vector2)transform.position;

				// Calculate the angle between the current and desired position
				float angle = Vector2.SignedAngle ((Vector2)(transform.up), (Vector2)(desiredDir.normalized));

				// apply the turning torque
				turning = angle / (180.0f) * turningTorque;
			} 
			else
			{
				turning = 0.0f;
			}

			if (Input.GetMouseButton (1))
			{
				// Get the world point from the mouse position
				Vector2 aimPosition = (Vector2)Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f));

				// Get the vector to the desired positon 
				Vector2 desiredDir = aimPosition - (Vector2)transform.position;

				// Calculate the angle between the 
				float angle = Vector2.SignedAngle ((Vector2)(transform.up), (Vector2)(desiredDir.normalized));

				// Apply the thrust
				thrust = (180.0f - Mathf.Abs (angle)) / (180.0f) * thrustForce;
			}
			else
			{
				thrust = 0.0f;
			}
				
		}
			
		// Check if the thruster is on 
		var emitter = booster.emission;
		if (thrust > 0.0f)
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
        // Apply the current drag factor -- why?
        //rb.velocity -= rb.velocity * dragFactor * Time.deltaTime;

		// Apply Torques
		rb.AddTorque(turning);
		rb.AddForce (thrust * transform.up);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
        // TO DO - Trigger end condition or maybe just trigger losing a life or something
	}

}
