using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int HealHP;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealHP = 100;
            Destroy(transform.parent.gameObject);
        }
    }
}
