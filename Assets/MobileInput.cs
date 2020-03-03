using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    [Header("Accelerometer")]
    public float speed = 10;
    public bool tilt = true;
    [Header("Pinch Zoom")]
    public float perspectiveZoomSpeed = .5f;
    public float orthographicZoomSpeed = .5f;
    
    void Update()
    {
        if(tilt)
        {
            float accel = speed * Time.deltaTime;
            Accelerometer(accel);
        }
        PinchZoom();
    }

    void Accelerometer(float accel)
    {
        transform.Translate(Input.acceleration.x * accel, 0, Input.acceleration.z * accel);
    }

    void PinchZoom()
    {
        //If we have 2 fingers on screen
        if(Input.touchCount == 2)
        {
            //First touch input on screen
            Touch touchZero = Input.GetTouch(0);
            //Second touch input on screen
            Touch touchOne = Input.GetTouch(1);
            //Difference between current and previous positions (positive or negative value)
            Vector2 touchZeroPreviousPosition = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePreviousPosition = touchOne.position - touchOne.deltaPosition;
            //Magnitude difference between the first touches on screen
            float previousTouchMagitude = (touchZeroPreviousPosition - touchOnePreviousPosition).magnitude;
            //Magnitude difference between the current touches on screen
            float currentTouchMagnitude = (touchZero.position - touchOne.position).magnitude;
            //Magnitude difference between the 2
            float magnitudeDifference = previousTouchMagitude - currentTouchMagnitude;

            if(Camera.main.orthographic)
            {
                //Zoom in or out depending on magnitude
                Camera.main.orthographicSize += magnitudeDifference * orthographicZoomSpeed;
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize,0.1f);
            }
            else
            {
                //Zoom in or out depending on magnitude
                Camera.main.fieldOfView += magnitudeDifference * perspectiveZoomSpeed;

                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 180);
            }
        }
    }
}
