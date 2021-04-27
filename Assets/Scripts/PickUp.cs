using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private int count;
    public GameObject winTextObject;
    public GameObject brickwinTextObject;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI brickCountText;
    private int brickCount;

    public Wayfind2 wayfind;

    private void Start()
    {

        wayfind = GetComponent<Wayfind2>();
        
        count = 0;
        brickCount = 0;
        SetCountText ();
        SetBrickCountText();
        
        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
        brickwinTextObject.SetActive(false);
    }

   
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            
            wayfind.Collectable.Remove(other.gameObject);
            
           Destroy(other.gameObject);
           //other.gameObject.SetActive(false);

            count = count + 1;
            
            SetCountText();
        }
        if (other.gameObject.CompareTag("brick"))
        {
            other.gameObject.SetActive(false);

            brickCount = brickCount + 1;
            
            SetBrickCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Tsukumogami:" + count.ToString();
        if (count >=8) 
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
    }
    void SetBrickCountText()
    {
        brickCountText.text = "brick:" + brickCount.ToString();
        if (brickCount >=2) 
        {
            // Set the text value of your 'winText'
            brickwinTextObject.SetActive(true);
        }
    }
  

   
}
