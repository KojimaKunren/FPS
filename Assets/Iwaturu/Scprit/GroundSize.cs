using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSize : MonoBehaviour
{
    public Vector3 size;
    // Start is called before the first frame update
    void Awake()
    {
        size = GetComponent<MeshRenderer>().bounds.size;
        // Debug.Log(size);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
