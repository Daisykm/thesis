using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
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

  
    void Update()
    {
        
            if ( colliding )
            {
                SceneManager.LoadScene("10_modular");
            }
        
    }
}
