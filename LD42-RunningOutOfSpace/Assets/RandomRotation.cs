using UnityEngine;

public class RandomRotation : MonoBehaviour {

    float rotationSpeed;
    public float rotationMultiplier;

    private float RandRotSpeed()
    {
        rotationSpeed = Random.value * rotationMultiplier;

        return rotationSpeed;
    }

    private void Start()
    {
        RandRotSpeed();
    }

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
}
