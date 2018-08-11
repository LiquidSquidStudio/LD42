using UnityEngine;

public class test_Satalite : MonoBehaviour {

    // Moved everything to do with general satellite motion to another script
    // Moved everything to do with gravity effects to another script

        // This Script now only contains things relevant to test satellites and their starting motion

	test_Planet planet;
	Rigidbody2D rb;

	float radius;
    float initialForce = 50.0f;

    // Sort references
    private void Awake()
    {
        planet = FindObjectOfType<test_Planet> ().GetComponent<test_Planet>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Initial Motion calculations
    private void Start()
    {
        radius = (planet.transform.position - transform.position).magnitude;
        float angle = Mathf.Atan2(transform.position.y, transform.position.x);
        Vector2 forceDir = new Vector2(-transform.position.y / Mathf.Tan(90 * Mathf.Deg2Rad - angle), radius * Mathf.Sin(angle));
        rb.AddForce(forceDir.normalized * initialForce);
    }
}
