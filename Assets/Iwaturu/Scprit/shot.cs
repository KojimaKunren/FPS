using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bulletPerfab;// 弾のプレハブ
    public int Maxremainingbullets, remainingbullets, ShotSpeed;//マガジンの装弾数 / マガジン内の残弾 /飛ばす力
    float timer = 0.0f;
    public float interval;

    private void Start()
    {
        remainingbullets = Maxremainingbullets;
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && timer <= 0.0f)
        {
            Shoot();
            timer = interval;
        }

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

    }
    public void Shoot()
    {
        if (remainingbullets > 0)
        {
            GameObject bullet = Instantiate(bulletPerfab, transform.position,
                Quaternion.Euler(
                    transform.position.x + Random.Range(-1.5f, 1.5f),
                    transform.position.y + Random.Range(-1.5f, 1.5f),
                    transform.position.z
                )
            );
            Rigidbody bulletOBJ = bullet.GetComponent<Rigidbody>();
            bulletOBJ.AddForce(transform.forward * ShotSpeed);
            remainingbullets -= 1;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3.0f);
        remainingbullets = Maxremainingbullets;
    }
}
