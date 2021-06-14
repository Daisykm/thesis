using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private int count;
    public GameObject winTextObject;
    public GameObject doorwinTextObject;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI doorCountText;
    private int doorCount;

    

    private SpiritVision wayfind1;
    private Wayfind2 wayfind2;
    private Wayfind3 wayfind3;

    public GameObject PressQ;
    public GameObject PressPickUp;
    public bool PressPickUpActive;

    public GameObject ExitLevel;

    

    private void Start()
    {

        wayfind1 = this.GetComponent<SpiritVision>();
        wayfind2 = this.GetComponent<Wayfind2>();
        wayfind3 = this.GetComponent<Wayfind3>();


        count = 0;
        SetCountText();
        
        ExitLevel.SetActive(false);
        
        
        
        //doorCount = 0;
       // SetDoorCountText();
   
        
        
        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
        //doorwinTextObject.SetActive(false);
        
        PressQ.SetActive(false);
        PressPickUp.SetActive(false);
        PressPickUpActive = false;

    }

   
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            PressPickUp.SetActive(true);
            PressPickUpActive = true;
        }
       
        

        if (other.gameObject.CompareTag("Door"))
        {
            PressQ.SetActive(true);

            //doorCount = doorCount + 1;

           // SetDoorCountText();


        }
        
        
    }

   private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q) && other.gameObject.CompareTag("pickup") && PressPickUpActive == true)
        {
            wayfind1.GlowOn.Remove(other.gameObject);
            wayfind2.Collectable.Remove(other.gameObject);
            wayfind3.Beacon.Remove(other.gameObject);
            wayfind3.GlowOff.Remove(other.gameObject);

            Destroy(other.gameObject);
            //other.gameObject.SetActive(false);

            count = count + 1;
            
            SetCountText();
            PressPickUp.SetActive(false);
            PressPickUpActive = false;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            PressQ.SetActive(false);
            
        }
        
        if (other.gameObject.CompareTag("pickup"))
        {
            PressPickUp.SetActive(false);
            PressPickUpActive = false;
            
        }
    }

    void SetCountText()
    {
        countText.text = "COLLECTABLES:" + count.ToString() + "/10";
        if (count >=10) 
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
            
            ExitLevel.SetActive(true);
            
            
            
        }
    }
   /* void SetDoorCountText()
    {
        doorCountText.text = "Doors Found:" + doorCount.ToString();
        if (doorCount >=2) 
        {
            // Set the text value of your 'winText'
            doorwinTextObject.SetActive(true);
        }
    }*/
  

   
}
