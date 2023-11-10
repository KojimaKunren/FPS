using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    private CharacterController characterController;

    public GameObject gun;

    public GameObject bullet;
    public GameObject beam;
    
    public float bulletSpeed;
    public float beamLifeTime;

    private Vector3 moveVelocity;
    private Vector3 moveRotate;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVelocity.z += Input.GetAxis("Vertical") * speed;

        if (characterController.isGrounded)
        {
            Jump();
        }
        else
        {
            moveVelocity.y += Physics.gravity.y;
            if (moveVelocity.y < 2.5f) moveVelocity.y = 2.5f;
        }

        moveVelocity.x += Input.GetAxis("Horizontal") * speed;
        this.transform.position = moveVelocity * Time.deltaTime;
        this.transform.Rotate(0.0f, moveVelocity.x, 0.0f);

        if (Input.GetMouseButtonDown(0) && gun.tag == "gun1")
        {
            shotBullet();
        }

        if (Input.GetMouseButtonDown(0) && gun.tag == "gun2")
        {
            shotBeam();
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            moveVelocity.y = jumpPower;
        }
    }

    void shotBullet()
        {
            GameObject newBullet = Instantiate(bullet,
    this.transform.position + new Vector3(1, 0, 0),
    this.transform.rotation) as GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }

    private void shotBeam()
    {
        GameObject newBeam = Instantiate(beam,
            this.transform.position + new Vector3(1, 0, 0),
            this.transform.rotation) as GameObject;

        Rigidbody beamRB = newBeam.GetComponent<Rigidbody>();
        Destroy(newBeam, beamLifeTime);
    }

}
