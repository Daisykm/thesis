using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class SpiritVision : MonoBehaviour
{
    public Material _material;
    private static int Opacity = Shader.PropertyToID("_opacity");
    private bool isSpiritVisionOn;
  
 
    void Start()
    { 
        _material = GetComponent<Renderer>().material;
      
        
  
        isSpiritVisionOn = false;

    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSpiritVisionOn == false)
        { 
            _material.SetFloat(Opacity,1);
        
            isSpiritVisionOn = true;
       

         



        }

        else if  (Input.GetKeyDown(KeyCode.E) && isSpiritVisionOn == true)
        {
            _material.SetFloat(Opacity,0);
            isSpiritVisionOn = false;
            


        }
       
    }
  
}
