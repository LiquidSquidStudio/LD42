using UnityEngine;

public class Gravity : MonoBehaviour {

    // Attach this component to anything that needs to get effected by gravity.
    // Need to make a corresponding script for the gravity "source"

    GravitySource gravitySource;
    public float mass;
    public bool effectedByGravity = true;

    Rigidbody2D rb;
    Vector2 forceDueToGravity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravitySource = FindObjectOfType<GravitySource>();
    }

    // Force due to gravity is calculated using the formula: F = Gm1m2/r2
    // Returned as a 2D vector for direction as well
    Vector2 GravityForce()
    {
        Vector2 distanceVector = gravitySource.transform.position - this.transform.position;
        float distance = distanceVector.magnitude;

        float force = mass * gravitySource.massAndG / (distance*distance);

        Vector2 direction = distanceVector.normalized;

        forceDueToGravity = direction * force;

        return forceDueToGravity;
    }

    // Apply force due to gravity only if the bool is checked
    private void FixedUpdate()
    {
        if (effectedByGravity)
        {
            rb.AddForce(GravityForce());
        }
    }
}
