using UnityEngine;

public class GravityEffects : MonoBehaviour {

    Rigidbody2D rb;
    test_Planet planet;

    float mass = 1.0f;

    // Setup references
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        planet = FindObjectOfType<test_Planet>().GetComponent<test_Planet>();
    }
    
    private void FixedUpdate()
    {
        // Apply gravity (F = mv/r^2)
        float distance = (planet.transform.position - transform.position).sqrMagnitude;
        rb.AddForce((planet.transform.position - transform.position).normalized * planet.gravity * mass / distance);
    }
}
