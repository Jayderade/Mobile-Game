using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsController))]
public class ShakeDetector : MonoBehaviour
{
    public float shakeDetectionThreshold;
    public float miniShakeInterval;
    public float sqrShakeDetectionThreshold;
    public float timeSinceLastShake;
    public PhysicsController physicsController;

    // Start is called before the first frame update
    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(shakeDetectionThreshold, 2);
        physicsController = GetComponent<PhysicsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.acceleration.sqrMagnitude >= shakeDetectionThreshold && Time.unscaledTime >= timeSinceLastShake + miniShakeInterval)
        {
            physicsController.ShakeRigidbodies(Input.acceleration);
            timeSinceLastShake = Time.unscaledTime;
        }
    }
}
