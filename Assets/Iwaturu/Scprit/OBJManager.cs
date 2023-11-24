using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OBJManager : MonoBehaviour
{
    public GameObject OBJDirecterPrefabs;
    public MeshRenderer ground;
    Vector3 size;
    // Start is called before the first frame update
    void Start()
    {
        size = ground.bounds.size;
        var parent = this.transform;
        for (int i = 0; i < 50; i++)
        {
            float rangex = Random.Range(-(size.x / 2.0f), size.x / 2.0f);
            float rangez = Random.Range(-(size.z / 2), size.z / 2);
            GameObject stage = Instantiate(OBJDirecterPrefabs, new Vector3(transform.position.x + rangex, 1f, transform.position.z + rangez),
                Quaternion.Euler(0, 0, 0), parent);
        }
    }
    // インスタンスするpositionが別OBJと接触していた場合、再インスタンスをする
    // forの中にwhileをおいて問題が無くなるまで抽選する
    void Update()
    {
        StageSet();
        StageSet();
    }
    IEnumerator StageSet()
    {
        yield return new WaitForSeconds(180.0f);
        var parent = this.transform;
        for (int i = 0; i < 50; i++)
        {
            float rangex = Random.Range(-(size.x / 2.0f), size.x / 2.0f);
            float rangez = Random.Range(-(size.z / 2), size.z / 2);
            GameObject stage = Instantiate(OBJDirecterPrefabs, new Vector3(rangex, 1f, rangez),
                Quaternion.Euler(0, 0, 0), parent);
        }
    }
}
