using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public int ShotSpeed;//飛ばす力    
    public GameObject bulletPerfab;// 弾のプレハブ

    // public GameObject muzzlePrefab1; //マズルフラッシュのプレハブ

    // public GameObject muzzlePrefab2; //マズルフラッシュのプレハブ
    public int Maxremainingbullets;
    public int remainingbullets;//マガジン内の残弾

    float timer = 0.0f;
    public float interval;


    private void Start()
    {
        remainingbullets = Maxremainingbullets;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && timer <= 0.0f)
        {
            Shot();
            timer = interval;
        }

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

    }
    public void Shot()
    {
        if (remainingbullets > 0)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPerfab, transform.position,
                Quaternion.Euler(
                    transform.position.x + Random.Range(-1.5f, 1.5f),
                    transform.position.y + Random.Range(-1.5f, 1.5f),
                    transform.position.z
                )
            );

            Rigidbody bulletOBJ = bullet.GetComponent<Rigidbody>();
            bulletOBJ.AddForce(this.transform.forward * ShotSpeed);
            bulletOBJ.AddTorque(new Vector3(transform.position.x, transform.position.y, transform.position.z));
            remainingbullets -= 1;

            //マズルフラッシュ
            // fireMuzzleFlash();
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

    //マズルフラッシュ
    // public void fireMuzzleFlash()
    // {
    //     Vector3 muzzleFlashPos = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);
    //     Vector3 muzzleFlashRot = new Vector3(transform.rotation.x + 180.0f, transform.rotation.y, transform.rotation.z);
    //     Instantiate(muzzlePrefab1, muzzleFlashPos, Quaternion.Euler(muzzleFlashRot));
    //     Instantiate(muzzlePrefab2, muzzleFlashPos, transform.rotation);
    // }
}
