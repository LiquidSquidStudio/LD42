using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEffects : MonoBehaviour {

    test_Planet planet;
    float mass = 1.0f;
    float dragFactor = 0.01f;

    Rigidbody2D rb;

    private void Awake()
    {
        // Get a reference to the rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Get a reference to the planet 
        planet = FindObjectOfType<test_Planet>().GetComponent<test_Planet>();
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
