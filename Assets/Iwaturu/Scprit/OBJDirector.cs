using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OBJDirector : MonoBehaviour
{
    OBJDestroy OBJDestroy;
    bool isTimerBreak;
    public int OBJbreak;
    int rand;
    int index;
    public GameObject itemDropPrefabs;
    public GameObject[] OBJPrefabs;
    public GameObject[] NoOBJPrefabs;

    public int OBJHP;

    void Start()
    {
        OBJbreak = 10000;
        var parent = this.transform;
        rand = Random.Range(0, 100);
        if (rand < 40)
        {
            index = Random.Range(0, OBJPrefabs.Length);
            GameObject item = Instantiate(OBJPrefabs[index], transform.position,
                Quaternion.Euler(0, 0, 0), parent);
            OBJDestroy = this.transform.GetChild(0).GetComponent<OBJDestroy>();
            OBJHP = OBJDestroy.MAXHP;
            isTimerBreak = OBJDestroy.isTimerBreak;
        }
        else
        {
            index = Random.Range(0, NoOBJPrefabs.Length);
            GameObject item = Instantiate(NoOBJPrefabs[index], transform.position,
                Quaternion.Euler(0, 0, 0), parent);
        }
    }
    public void Drop()
    {
        if (isTimerBreak == false)
        {
            var parent = this.transform;
            GameObject item = (GameObject)Instantiate(itemDropPrefabs, transform.position,
                Quaternion.Euler(0, 0, 0), parent);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
