using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float run = Input.GetAxis("vertical");
        animator.SetFloat("Run", run);

        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Jump");
        }
    }
}
