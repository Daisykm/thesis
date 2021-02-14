using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;

    Animator anim;

    public Transform cam;
    public Transform groundCheck;

    float playerSpeed;
    float gravity = -19.6f;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float walkSpeed = 6f;
    public float runSpeed = 10f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;

    public LayerMask groundMask;

    ClimbController climb;

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();

        climb = GetComponent<ClimbController>();

        playerSpeed = walkSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        if (climb.isClimbing == false)
        {

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
                anim.SetBool("isJumping", false);
            }

            float horizontal = Input.GetAxisRaw("Horizontal");

            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                anim.SetBool("isJumping", true);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

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
}
