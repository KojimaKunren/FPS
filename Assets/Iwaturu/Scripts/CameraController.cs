using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotationX;
    float rotationY;

    public float Xsensityvity;

    public float Ysensityvity;

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * Xsensityvity;
        rotationY += Input.GetAxis("Mouse Y") * Ysensityvity;
        transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0.0f);
    }
}
