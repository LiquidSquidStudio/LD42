﻿using UnityEngine;

public class RotationController : MonoBehaviour {

    float rotationSpeed;
    public float rotationMultiplier;
    public bool isRandom = true;

    private void Start()
    {
        RandRotSpeed();
    }

    private float RandRotSpeed()
    {
        if (isRandom)
            rotationSpeed = Random.value * rotationMultiplier;
        else
            rotationSpeed = 1 * rotationMultiplier;

        return rotationSpeed;
    }

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
}
