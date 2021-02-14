using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private int count;
    
  
    public TextMeshProUGUI countText;
    

    private void Start()
    {
        count = 0;
        
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Tsukumogami:" + count.ToString();
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            
            SetCountText();
        }
        
        if (other.gameObject.CompareTag("brick"))
        {
            other.gameObject.SetActive(false);
        }
     
        
    }
    
    
  

   
}
