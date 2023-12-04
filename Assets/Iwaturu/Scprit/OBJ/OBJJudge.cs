using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJJudge : MonoBehaviour
{
    [HideInInspector] public bool judge;
    void Start()
    {
        judge = false;
    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag == "Ground")) judge = true;
        Debug.Log(judge);
    }
    private void OnTriggerStay(Collider other)
    {
        if (!(other.gameObject.tag == "Ground")) judge = true;
        Debug.Log(judge);

    }
    private void OnTriggerExit(Collider other)
    {
        if (!(other.gameObject.tag == "Ground")) judge = false;
        Debug.Log(judge);

    }
}
