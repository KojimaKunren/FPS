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
    private void Start()
    {
        isTimerBreak = false;
        breakDamage = 0;
        int index = Random.Range(0, HPs.Length);
        MAXHP = HPs[index];
        HP = MAXHP;
    }

    private void Update()
    {
        Breaker();
        HP -= breakDamage;
        if (HP <= 1000)
        {
            isTimerBreak = true;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
        {

            BulletATK = other.gameObject.GetComponent<Bullet>();
            HP -= BulletATK.attack;
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }

    }
    IEnumerator Breaker()
    {
        yield return new WaitForSeconds(180.0f);
        OBJ = gameObject.GetComponent<OBJDirector>();
        breakDamage = OBJ.OBJbreak;
    }

}
