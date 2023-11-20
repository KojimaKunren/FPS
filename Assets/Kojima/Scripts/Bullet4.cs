using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4
 : MonoBehaviour
{
    public int attack;
    [SerializeField] private AudioSource shotSE1;
    [SerializeField] private AudioSource shotSE2;

    void Start()
    {
        shotSE1.Play();
        shotSE2.Play();
    }

}