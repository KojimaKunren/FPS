using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NobreakOBJ : MonoBehaviour
{
    OBJDirector OBJ;
    bool isTimerBreak;

    // Start is called before the first frame update
    void Start()
    {
        isTimerBreak = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Breaker());
        if (isTimerBreak)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
    IEnumerator Breaker()
    {
        yield return new WaitForSeconds(20.0f);
        OBJ = gameObject.GetComponent<OBJDirector>();
        isTimerBreak = true;
    }
}
