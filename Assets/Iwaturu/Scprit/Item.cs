using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    OBJDirector oBJDestroy;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        oBJDestroy = transform.parent.GetComponent<OBJDirector>();
        score = oBJDestroy.OBJHP * 10;
        Vector3 rote = new(transform.rotation.x, transform.rotation.y, transform.rotation.z);
    }
    private void Update()
    {
        Rigidbody rd = GetComponent<Rigidbody>();
        if (this.transform.position.y <= 0.3f)
        {
            rd.useGravity = false;

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
