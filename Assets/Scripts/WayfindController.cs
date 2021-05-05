using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WayfindController : MonoBehaviour
{
    
    //private SpiritVision _wayfind1;

    //private Wayfind2 _wayfind2;

    //private Wayfind3 _wayfind3;
    
    //UI

    public GameObject WayfindingONText;
    public GameObject WayfindingOFFText;
    

    public bool isWayfindingOn;

    private void Start()
    {
        //_wayfind1 = GetComponent<SpiritVision>();
        //_wayfind2 = GetComponent<Wayfind2>();
        //_wayfind3 = GetComponent<Wayfind3>();
        
        

        isWayfindingOn = false;
        WayfindingOFFText.SetActive(true);
        WayfindingONText.SetActive(false);
    }

    private void Update()
    {
        if (isWayfindingOn == true)
        {
            WayfindingONText.SetActive(true);
            WayfindingOFFText.SetActive(false);
        }
        else if (isWayfindingOn == false)
        {
            WayfindingOFFText.SetActive(true);
            WayfindingONText.SetActive(false);
            
        }
        
    }
}
