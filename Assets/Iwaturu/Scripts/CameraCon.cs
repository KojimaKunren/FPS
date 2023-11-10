using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    float rotationX;
    float rotationY;

    public float Xsensityvity;

    public float Ysensityvity;

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * Xsensityvity;
        rotationY += Input.GetAxis("Mouse Y") * Ysensityvity;

        if (rotationY > 125.0f) rotationY = 125.0f;
        if (rotationY < -125.0f) rotationY = -125.0f; 

        transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0.0f);
    }

}
