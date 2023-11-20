using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OBJDirector : MonoBehaviour
{
    OBJDestroy OBJDestroy;
    bool isTimerBreak;
    public int OBJbreak;
    public GameObject[] itemPrefabs;
    public GameObject[] OBJPrefabs;

    public GameObject[] NoOBJPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        OBJbreak = 10000;
        OBJDestroy = this.transform.GetChild(0).GetComponent<OBJDestroy>();
        isTimerBreak = OBJDestroy.isTimerBreak;
        var parent = this.transform;
        int rand = Random.Range(0, 100);
        if (rand < 40)
        {
            int index = Random.Range(0, OBJPrefabs.Length);
            GameObject item = (GameObject)Instantiate(OBJPrefabs[index], transform.position,
                Quaternion.Euler(transform.position.x, transform.position.y, transform.position.z), parent);
        }
        else
        {
            int index = Random.Range(0, NoOBJPrefabs.Length);
            GameObject item = (GameObject)Instantiate(NoOBJPrefabs[index], transform.position,
                Quaternion.Euler(transform.position.x, transform.position.y, transform.position.z), parent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerBreak == false)
        {
            var parent = this.transform;
            int rand = Random.Range(0, 100);
            if (rand < 75)
            {
                GameObject item = (GameObject)Instantiate(itemPrefabs[0], transform.position,
                    Quaternion.Euler(transform.position.x, transform.position.y, transform.position.z), parent);
            }
            else
            {
                GameObject item = (GameObject)Instantiate(itemPrefabs[1], transform.position,
                    Quaternion.Euler(transform.position.x, transform.position.y, transform.position.z), parent);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
