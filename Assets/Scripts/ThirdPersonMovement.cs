using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;

    Animator anim;

    public Transform cam;

    float playerSpeed;

    public float walkSpeed = 6f;
    public float runSpeed = 10f;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();

        playerSpeed = walkSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerSpeed = runSpeed;
            }
            else
            {
                playerSpeed = walkSpeed;
            }

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);

            if (playerSpeed == walkSpeed)
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
            }
            else if (playerSpeed == runSpeed)
            {
                anim.SetBool("isRunning", true);
            }

        }
        else
        {
            anim.SetBool("isWalking", false);

            anim.SetBool("isRunning", false);
        }

    }
}
