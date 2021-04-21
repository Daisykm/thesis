using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private bool colliding;

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        if (colliding && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("10_modular");
        }
        
    }
}
