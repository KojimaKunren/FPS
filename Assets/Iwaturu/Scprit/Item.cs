using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    OBJDestroy oBJDestroy;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        oBJDestroy = gameObject.GetComponent<OBJDestroy>();
        score = oBJDestroy.MAXHP;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(transform.parent);
        }
    }
}
