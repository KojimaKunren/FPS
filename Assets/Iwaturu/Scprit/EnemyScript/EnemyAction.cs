using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    const int MaxHp = 100;
    [HideInInspector] public int hp;
    public float speed;
    float rote;
    bool capture;
    public GameObject itemPrefab;
    EnemySearch enemySearch;
    Bullet bulletATK;
    Rigidbody rb;
    Animator animator;
    GameObject target;
    Vector3 result;

    void Start()
    {
        hp = MaxHp;
        speed = 10.0f;
        enemySearch = transform.GetChild(0).GetComponent<EnemySearch>();
        rb = GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        capture = enemySearch.IsCapture;
        if (capture == false)
        {
            rb.velocity = transform.forward * speed;
            animator.SetBool("walk", true);
        }
        else
        {
            PlayerLook();
            rb.velocity = Vector3.zero;

            animator.SetBool("walk", false);
        }
    }

    public void PlayerLook()
    {
        Vector3 relativePos = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1.0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "OBJ" || other.gameObject.tag == "FildOBJ")
        {
            // 入射ベクトル（速度）
            var inDirection = rb.velocity;
            // 法線ベクトル
            var inNormal = transform.up;
            // 反射ベクトル（速度）
            result = Vector3.Reflect(inDirection, inNormal);
        }

    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "FildOBJ" || other.gameObject.tag == "OBJ")
        {
            if (result.y < 90.0f)
            {
                rote = 3.0f;
            }
            else if (result.y >= 90.0f)
            {
                rote = -3.0f;
            }
            transform.Rotate(0, rote, 0);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            bulletATK = other.gameObject.GetComponent<Bullet>();
            hp -= bulletATK.attack;
            if (hp <= 0)
            {
                float rangeXZ = Random.Range(1.5f, 2f);
                float randX = Random.Range(-rangeXZ, rangeXZ);
                float randZ = Random.Range(-rangeXZ, rangeXZ);
                GameObject item = Instantiate(itemPrefab, transform.position,
                    Quaternion.Euler(-90, 0, 0));
                Rigidbody rd = item.GetComponent<Rigidbody>();
                rd.AddForce(new Vector3(randX, 7f, randZ), ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
    //アニメーションエラー対応用
    private void OnFootstep()
    {

    }

    //アニメーションエラー対応用
    private void OnLand()
    {

    }
}
