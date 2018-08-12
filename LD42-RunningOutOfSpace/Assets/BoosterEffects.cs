using UnityEngine;

public class BoosterEffects : MonoBehaviour {

    [HideInInspector]
    public bool boostersOn = false;
    ParticleSystem exhaust;

    // Get the booster particle system reference sorted, and turn it off initially
    private void Awake()
    {
        exhaust = GetComponentInChildren<ParticleSystem>();

        var emitter = exhaust.emission;
        emitter.enabled = false;
    }

    private void Update()
    {
        var emitter = exhaust.emission;
        emitter.enabled = boostersOn;
    }
}
