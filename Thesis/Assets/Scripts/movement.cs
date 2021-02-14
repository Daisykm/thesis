using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed = 2f;

    //Animator m_Animator;

    public CharacterController controller;

    public GameObject playerBody;

    void Start()
    {
       // m_Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        move.Normalize();

        Vector3 newPosition = new Vector3(x, 0.0f, z);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);

        bool hasHorizontalInput = !Mathf.Approximately(x, 0f);
        bool hasVerticalInput = !Mathf.Approximately(z, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

      //  m_Animator.SetBool("IsWalking", isWalking);


    }
}
