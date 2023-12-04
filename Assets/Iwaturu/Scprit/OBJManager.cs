using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UIElements;

public class OBJManager : MonoBehaviour
{
    public GameManager GM;
    public MeshRenderer ground;
    public GameObject OBJDirecterPrefabs, empty;
    [HideInInspector] public Vector3 size;
    [HideInInspector] public float coroTime;
    [HideInInspector] public int Yrand;
    Vector3 posi, halfExtents;
    void Start()
    {
        coroTime = /*GM.timer /*/ 30.0f;
        posi = ground.transform.position;
        size = ground.bounds.size;
        halfExtents = empty.GetComponent<BoxCollider>().bounds.size / 2;
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(StageSet(i));
        }
    }
    IEnumerator StageSet(int col)
    {
        yield return new WaitForSeconds(coroTime * col);
        var parent = transform;
        int counter = 0;
        while (counter < 50)
        {
            float rangex = Random.Range(-(size.x / 2.0f), size.x / 2.0f);
            float rangez = Random.Range(-(size.z / 2.0f), size.z / 2.0f);
            Vector3 vec = new(rangex + posi.x, 0.5f, rangez + posi.z);
            Yrand = Random.Range(1, 7) * 30;
            if (!Physics.CheckBox(vec, halfExtents, Quaternion.Euler(0, Yrand, 0), 1 << 12))
            {
                Instantiate(OBJDirecterPrefabs, vec, Quaternion.Euler(0, Yrand, 0), parent);
                counter++;
            }
        }
    }
}

