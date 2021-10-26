using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCube : MonoBehaviour
{
    public float rotateSpeedX;
    public float rotateSpeedY;
    public float rotateSpeedZ;

    float speedX;
    float speedY;
    float speedZ;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speedX = rotateSpeedX;
        speedY = rotateSpeedY;
        speedZ = rotateSpeedZ;
        transform.Rotate(speedX * Time.fixedDeltaTime, speedY * Time.fixedDeltaTime, speedZ * Time.fixedDeltaTime, Space.Self);
    }
}
