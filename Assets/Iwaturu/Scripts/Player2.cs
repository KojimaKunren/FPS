using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public int hp;

    CharacterController characterController;
    Vector3 characterPosition;
    float positionX;
    float positionZ;
    float rotationX;
    float rotationY;
    Quaternion characterRotation;

    public GameObject cameraObject;
    public float SensityvityX;
    public float SensityvityY;

    Quaternion cameraRotation;
    float minX = -90f;
    float maxX = 90f;

    Animator animator;

    bool cursorLock;



    void Start()
    {
        cameraRotation = cameraObject.transform.localRotation;

        characterRotation = transform.localRotation;
        characterPosition = transform.localPosition;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        cursorLock = true;
    }

    void Update()
    {
        rotationX = Input.GetAxis("Mouse X") * SensityvityY;
        rotationY = Input.GetAxis("Mouse Y") * SensityvityX;

        if (Input.GetKeyDown("space"))
        {
            Jump();
            animator.SetTrigger("JumpStart");
        }
        else
        {
            characterPosition.y = Physics.gravity.y * Time.deltaTime;
        }

        cameraRotation *= Quaternion.Euler(-rotationY, 0, 0);
        characterRotation *= Quaternion.Euler(0, rotationX, 0);

        cameraRotation = ClampRotation(cameraRotation);

        cameraObject.transform.localRotation = cameraRotation;
        transform.localRotation = characterRotation;
        characterController.Move(characterPosition);

        UpdateCursorLock();

    }

    // private void FixedUpdate()
    // {
    //     positionX = 0;
    //     positionZ = 0;

    //     positionX = Input.GetAxisRaw("Horizontal") * speed * Time.fixedTime;
    //     positionZ = Input.GetAxisRaw("Vertical") * speed * Time.fixedTime;

    //     transform.position += cameraObject.transform.forward * positionZ + cameraObject.transform.right * positionX;

    //     animator.SetBool("Walk_N", positionZ < 0.0f);

    // }

    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    void Jump()
    {
        if (characterController.isGrounded)
        {
            characterPosition.y += jumpPower;
        }
    }

    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX, minX, maxX);
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
}
