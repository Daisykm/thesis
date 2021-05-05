using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wayfind3 : MonoBehaviour
{

    public List<GameObject> Beacon = new List<GameObject>();
    
    public List<GameObject> GlowOff = new List<GameObject>();
    
    //public GameObject Beacon;
    private bool beaconActive;
    //private bool isSpiritVisionOn;
    //public GameObject GlowOff;
    //public GameObject GlowOn;
    
    //private GameObject player;
    
    private WayfindController _wayfindController;

    public GameObject BeaconONText;
    public GameObject BeaconOFFText;
    
    void Start()
    {
        
        Beacon.AddRange(GameObject.FindGameObjectsWithTag("beacon"));
        
        GlowOff.AddRange(GameObject.FindGameObjectsWithTag("glowOff"));

        foreach (GameObject beacon in Beacon)
        {
            beacon.SetActive(false);
        }
        
        //Beacon.SetActive(false);
        beaconActive = false;
        //isSpiritVisionOn = false;
        
        //player = GameObject.FindGameObjectWithTag("Player");
        
        _wayfindController = this.GetComponent<WayfindController>();
        
        BeaconONText.SetActive(false);
        BeaconOFFText.SetActive(true);
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && beaconActive == false && _wayfindController.isWayfindingOn == false)
        {

            foreach (GameObject beacon in Beacon)
            {
                if (beacon != null)
                {
                    beacon.SetActive(true);
                }
              
                
            }
            
            foreach (GameObject glowOff in GlowOff)
            {
                if (glowOff != null)
                {
                    glowOff.SetActive(false);
                }
                

            }
            
            //Beacon.SetActive(true);
            
            beaconActive = true;
            
            //GlowOff.SetActive(false);
            //GlowOn.SetActive(true);
            
            _wayfindController.isWayfindingOn = true;
            //isSpiritVisionOn = false;
            
            BeaconONText.SetActive(true);
            BeaconOFFText.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.T) && beaconActive == true && _wayfindController.isWayfindingOn == true)
        { 
            
            foreach (GameObject beacon in Beacon)
            {
                if (beacon != null)
                {
                    beacon.SetActive(false);
                }
                
                
            }
            
            foreach (GameObject glowOff in GlowOff)
            {
                if (glowOff != null)
                {
                    glowOff.SetActive(true);
                }

                

            }
            
            //Beacon.SetActive(false);
            
            beaconActive = false;
            
            //GlowOff.SetActive(true);
            //GlowOn.SetActive(false);
            
            _wayfindController.isWayfindingOn = false;
            //isSpiritVisionOn = false;
            BeaconONText.SetActive(false);
            BeaconOFFText.SetActive(true);
        }
        
        
    

    }
}
