using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CubeGround : MonoBehaviour
{
    Vector3 vector;
    public float speed;

    void Start()
    {
        vector = GetComponent<Transform>().localScale;
    }

    void Update()
    {
        if (vector.x > 100)
        {
            vector.x = vector.x - 2 * Time.deltaTime * speed;
            vector.y = vector.y + 5 * Time.deltaTime * speed;
            vector.z = vector.z - 2 * Time.deltaTime * speed;

            transform.localScale = vector;
        }
    }
}
