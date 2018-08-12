using UnityEngine;

public class LaunchControls : MonoBehaviour {

    Rigidbody2D rb;
    BoosterEffects boosterEffects;
    
    float timer;
    float burnTime;
    bool boosterIsOn = false;

    float thrust;
    public float thrustForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boosterEffects = GetComponent<BoosterEffects>();
    }

    private void Start()
    {
        thrust = 0.5f;
    }

    public void LaunchRocket(float burnFor)
    {
        timer = 0f;
        burnTime = burnFor;
        boosterIsOn = true;
        // TO DO - set the angle
    }

    void BoostersAreOn()
    {
        if (boosterIsOn)
        {
            thrust = thrustForce;
        }
        else
        {
            thrust = 0;
        }

        boosterEffects.boostersOn = boosterIsOn;
        rb.AddForce(thrust * transform.up);
    }

    private void Update()
    {
        // In place of a coroutine, I'm just gonna have this janky update and bool timer thing running
        BoostersAreOn();

        timer += Time.deltaTime;

        if (timer > burnTime)
        {
            boosterIsOn = false;
        }
    }

}
