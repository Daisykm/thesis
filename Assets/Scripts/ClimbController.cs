using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{

    public bool isClimbing;
    bool canStartClimb;

    Animator anim;

    public CharacterController controller;

    public Transform cam;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float checkClimbDistance = 1f;

    public float climbSpeed = 2f;

    public LayerMask climable;

    RaycastHit hitHolder;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();

        canStartClimb = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForClimbing();

        if(canStartClimb && Input.GetKey(KeyCode.Space))
        {

            isClimbing = true;

            float horizontal = Input.GetAxisRaw("Horizontal");

            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, vertical, 0f).normalized;

            if (direction.magnitude >= 0.1f)
            {

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.up;
                controller.Move(moveDir.normalized * climbSpeed * Time.deltaTime);

                anim.SetBool("isClimbing", true);

            }

        }
        else
        {
            isClimbing = false;

            anim.SetBool("isClimbing", false);

        }

    }

    void CheckForClimbing()
    {
        RaycastHit hit;
        Vector3 origin = transform.position;
        origin.y -= 2f;

        if(Physics.Raycast(origin, transform.forward, out hit, checkClimbDistance, climable))
        {
            canStartClimb = true;
            hitHolder = hit;
            
        }
        else
        {
            canStartClimb = false;
        }
    }

}
