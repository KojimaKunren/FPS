using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class OBJDestroy : MonoBehaviour
{
    Bullet BulletATK;
    OBJDirector OBJ;
    int[] HPs = new int[] { 50, 100, 300, 700, 1000 };
    int HP;
    public int MAXHP;
    public bool isTimerBreak;
    int breakDamage;
    Vector3 Object;

    float Gravity;

    private void Awake()
    {
        OBJ = transform.parent.GetComponent<OBJDirector>();
        Object = gameObject.GetComponent<Transform>().position;
        Gravity = -1;
    }

    private void Start()
    {
        isTimerBreak = false;
        Debug.Log($"start:{isTimerBreak}");
        breakDamage = 0;
        int index = Random.Range(0, HPs.Length);
        MAXHP = HPs[index];
        HP = MAXHP;

    }

    private void Update()
    {
        StartCoroutine(Breaker());
        Object = new Vector3(Object.x, Object.y - 1, Object.z);
        HP -= breakDamage;
        if (isTimerBreak)
        {
            isTimerBreak = true;
            Destroy(this.transform.parent.gameObject);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        Gravity = -0.001f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            BulletATK = other.gameObject.GetComponent<Bullet>();
            HP -= BulletATK.attack;
            if (HP <= 0 || HP >= -999)
            {
                OBJ.Drop();
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator Breaker()
    {
        yield return new WaitForSeconds(20.0f);
        isTimerBreak = true;
        Debug.Log($"IEnumerator: {isTimerBreak}");
        breakDamage = OBJ.OBJbreak;
    }
}
