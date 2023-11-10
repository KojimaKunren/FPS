using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;

    float basicSpeed;
    float basicJumpPower;
    public float sensivytivy;

    public float speedRotation;

    public int hp;

    public GameObject playerCamera;
    Vector3 cameraPosition;

    Animator animator;
    Vector3 playerPosition;

    Vector3 playerScale;

    Vector3 playerRotation = Vector3.zero;

    float positionX;
    float positionZ;

    float rotationX;
    float scaleY;

    float offsetZ;


    Rigidbody rb;

    public float jumpPower;

    bool isJump;

    bool isDead;

    bool cursorLock;

    //動きの状態
    bool isCrouch;

    bool isForcus;

    public GameObject gameOverCanvas;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerPosition = transform.localPosition;
        playerScale = transform.localScale;
        scaleY = playerScale.y;
        isJump = false;
        isCrouch = false;
        isDead = false;
        isForcus = false;
        animator.SetFloat("MotionSpeed", 1.0f);
        cursorLock = true;
        basicJumpPower = jumpPower;
        basicSpeed = speed;
        cameraPosition = playerCamera.transform.position;
        gameOverCanvas.SetActive(false);
        offsetZ = transform.position.z - playerCamera.transform.position.z;


    }

    void Update()
    {
        positionX = Input.GetAxis("Horizontal");
        positionZ = Input.GetAxis("Vertical");
        rotationX += Input.GetAxis("Mouse X") * speedRotation;
        playerRotation = new Vector3(0.0f, rotationX, 0.0f);
        transform.rotation = Quaternion.Euler(playerRotation);

        //ジャンプ
        if (Input.GetKeyDown("space") && !isJump)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
            animator.SetBool("Jump", true);
        }

        //しゃがみ
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouching();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ForcusAim();
        }

        UpdateCursorLock();
        IsDead();

        hp -= 1;

    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed * positionZ, ForceMode.VelocityChange);
        rb.AddForce(transform.right * speed * positionX, ForceMode.VelocityChange);
        animator.SetFloat("Speed", speed);

    }

    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || isDead)
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isJump = false;
            animator.SetBool("Jump", false);
            animator.SetBool("Grounded", true);
        }

        // if (other.gameObject.tag == "Bullet")
        // {
        //     hp -= other.gameObject.attack;
        // }
    }

    //しゃがみ
    private void Crouching()
    {
        if (!isCrouch)
        {
            playerScale.y = scaleY / 2.0f;
            transform.localScale = playerScale;
            speed = basicSpeed * 0.7f;
            float cameraPositionY = cameraPosition.y / 2.0f;
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, cameraPositionY, playerCamera.transform.position.z);
            isCrouch = true;
        }
        else
        {
            playerScale.y = scaleY;
            transform.localScale = playerScale;
            speed = basicSpeed;
            float cameraPositionY = cameraPosition.y;
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, cameraPositionY, playerCamera.transform.position.z);
            isCrouch = false;
        }

    }

    //GameOver判定
    //Button
    public bool IsDead()
    {
        if (hp <= 0)
        {
            isDead = true;
        }

        return isDead;

    }

    //Shot

    //Focus
    private void ForcusAim()
    {
        if (!isForcus)
        {
            jumpPower = basicJumpPower * 0.5f;
            speed = basicSpeed * 0.8f;
            sensivytivy *= 8f;
            float cameraPositionZ = playerCamera.transform.position.z + 20.0f;
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, cameraPositionZ);
            isForcus = true;
        }
        else
        {
            jumpPower = basicJumpPower;
            speed = basicSpeed;
            sensivytivy *= 0.8f;
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, transform.position.z - offsetZ);
            isForcus = false;
        }
    }


}
