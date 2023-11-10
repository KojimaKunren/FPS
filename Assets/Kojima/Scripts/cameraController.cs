using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float rotationSpeed;

    float rotationX;
    float rotationY;

    void Start()
    {

    }

    void Update()
    {
        rotationY += Input.GetAxis("Mouse X");
        rotationX += Input.GetAxis("Mouse Y");
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(-rotationX, rotationY, 0.0f);
    }
}
