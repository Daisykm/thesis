using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wayfind3 : MonoBehaviour
{
    public GameObject Beacon;
    private bool beaconActive;
    private bool isSpiritVisionOn;
    public GameObject GlowOff;
    public GameObject GlowOn;
    
    void Start()
    {
        Beacon.SetActive(false);
        beaconActive = false;
        isSpiritVisionOn = false;
       
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && beaconActive == false && isSpiritVisionOn == false)
        { 
            Beacon.SetActive(true);
            beaconActive = true;
            GlowOff.SetActive(false);
            GlowOn.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.R) && beaconActive == true && isSpiritVisionOn == false)
        { 
            Beacon.SetActive(false);
            beaconActive = false;
            GlowOff.SetActive(true);
            GlowOn.SetActive(false);
        }
        
        
        if (Input.GetKeyDown(KeyCode.E) && isSpiritVisionOn == false )
        { 
           
        
            isSpiritVisionOn = true;
            beaconActive = false;
            Beacon.SetActive(false);
            GlowOff.SetActive(false);
            GlowOn.SetActive(true);

        }

        else if  (Input.GetKeyDown(KeyCode.E) && isSpiritVisionOn == true )
        {
         
            isSpiritVisionOn = false;
            Beacon.SetActive(false);
            beaconActive = false;
            GlowOff.SetActive(true);
            GlowOn.SetActive(false);



        }

    }
}
