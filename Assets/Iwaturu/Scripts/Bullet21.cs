using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet21
    : MonoBehaviour
{
    public float onscreenDelay;

    void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("bullet");
    }
}
