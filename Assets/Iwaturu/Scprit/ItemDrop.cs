using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    void Start()
    {
        int randDrop = Random.Range(2, 6);
        for (int i = 0; i < randDrop; i++)
        {
            Drop();
        }
    }
    void Drop()
    {
        var parent = this.transform;
        int rand = Random.Range(0, 100);
        if (rand < 80)
        {
            float rangeXZ = Random.Range(1.5f, 2f);
            float randX = Random.Range(-rangeXZ, rangeXZ);
            float randZ = Random.Range(-rangeXZ, rangeXZ);
            GameObject item = Instantiate(itemPrefabs[0], transform.position,
                Quaternion.Euler(-90, 0, 0), parent);
            Rigidbody rd = item.GetComponent<Rigidbody>();
            rd.AddForce(new Vector3(randX, 7f, randZ), ForceMode.Impulse);

        }
        else
        {
            float rangeXZ = Random.Range(1.5f, 2f);
            float randX = Random.Range(-rangeXZ, rangeXZ);
            float randZ = Random.Range(-rangeXZ, rangeXZ);
            GameObject item = Instantiate(itemPrefabs[1], transform.position,
                Quaternion.Euler(0, 0, 0), parent);
            Rigidbody rd = item.GetComponent<Rigidbody>();
            rd.AddForce(new Vector3(randX, 7f, randZ), ForceMode.Impulse);
        }
    }
}
