using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float shakeForceMultiplier;
    public Rigidbody2D[] shakeableRigidbodys;

    public void ShakeRigidbodies(Vector3 deviceAcceleration)
    {
        foreach( var rigidbody in shakeableRigidbodys)
        {
            rigidbody.AddForce(deviceAcceleration * shakeForceMultiplier, ForceMode2D.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
