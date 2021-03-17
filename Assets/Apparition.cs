using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apparition : MonoBehaviour
{
    public Material _ghostMaterial;
    private static int Ghostness = Shader.PropertyToID("_ghostness");
    private bool areGhostsVisible;
    
    void Start()
    {
        _ghostMaterial = GetComponent<Renderer>().material;
        areGhostsVisible = false;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && areGhostsVisible == false )
        { 
            _ghostMaterial.SetFloat(Ghostness,1);
        
            areGhostsVisible = true;
            
            
        }

        else if  (Input.GetKeyDown(KeyCode.E) && areGhostsVisible == true )
        {
            _ghostMaterial.SetFloat(Ghostness,0);
            areGhostsVisible = false;
            
            
        }
    }
}
