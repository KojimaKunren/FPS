using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject hitPre;
    RaycastHit hit;
    Vector3 hitPos;
    private void Update()
    {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = new(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 1.0f))
        {
            if (!(hit.collider.gameObject.tag == "Player"))
            {
                hitPos = hit.point;
                // Debug.Log(hit.collider.gameObject.transform.position);
                // Debug.Log(hit.collider.gameObject.tag);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag == "bullet"))
        {
            Instantiate(hitPre, hitPos, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }
}
