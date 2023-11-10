using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    const int MaxHp = 10;
    public int hp;
    public float speed;
    EnemySearch enemySearch;
    Bullet bulletATK;
    Rigidbody rb;

    GameObject es;
    EnemyShot enemyShot;

    Animator animator;

    GameObject target;
    bool capture;

    void Start()
    {
        hp = MaxHp;
        speed = 10.0f;
        enemySearch = this.transform.GetChild(0).GetComponent<EnemySearch>();
        rb = this.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        capture = enemySearch.IsCapture;
        if (capture == false)
        {
            // rb.AddForce(this.transform.forward * speed);
            rb.velocity = this.transform.forward * speed;
            animator.SetBool("walk", true);
        }
        else
        {
            PlayerLook();
            // rb.AddForce(transform.forward * 0.0f);
            rb.velocity = Vector3.zero;

            animator.SetBool("walk", false);
        }

    }

    public void PlayerLook()
    {
        Vector3 relativePos = target.transform.position - this.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, 1.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            bulletATK = other.gameObject.GetComponent<Bullet>();
            hp -= bulletATK.attack;
            if (hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "FildOBJ")
        {
            this.transform.Rotate(0, 3, 0);
        }
    }
}
