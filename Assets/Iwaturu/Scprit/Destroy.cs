using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag == "Bullet"))
        {
            Destroy(this.gameObject);
        }

    }
}
