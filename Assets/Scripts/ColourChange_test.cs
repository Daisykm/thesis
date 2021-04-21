using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange_test : MonoBehaviour
{
    public Material _oldmaterial;
    public Color _newcolour;
    public int MainColour = Shader.PropertyToID("BaseColor");
    
    
    
    void Start()
    {
        _oldmaterial = GetComponent<Renderer>().material;
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _oldmaterial.SetColor("BaseColor",_newcolour);
            print("object should be new colour");
        }
    }
}
