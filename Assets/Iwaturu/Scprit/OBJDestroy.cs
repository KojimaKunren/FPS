using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJDestroy : MonoBehaviour
{
    Bullet BulletATK;
    public int HP = 100;
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
}
