using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEditor;


public class SpiritVision : MonoBehaviour
{
    
    public GameObject SpirtVolume;
    public GameObject thirdPersonCamera;
    public GameObject spiritVisionCamera;

    //public Material _material;
    private static int Opacity = Shader.PropertyToID("_opacity");
    private bool isSpiritVisionOn;
    private bool beaconActive;
    
    public List<GameObject> SeeThrough = new List<GameObject>();

    public List<Material> MaterialList = new List<Material>();
    
    public List<GameObject> GlowOn = new List<GameObject>();
    
    public List<GameObject> GlowOff = new List<GameObject>();

    private WayfindController _wayfindController;
    
    
 
  
 
    void Start()
    { 
        
        SeeThrough.AddRange(GameObject.FindGameObjectsWithTag("seeThrough"));
        
        GlowOn.AddRange(GameObject.FindGameObjectsWithTag("glowOn"));
        
        GlowOff.AddRange(GameObject.FindGameObjectsWithTag("glowOff"));

        foreach (GameObject seeThrough in SeeThrough)
        {
            Material _material = seeThrough.GetComponent<Renderer>().material;
            
            MaterialList.Add(_material);
        }
        
        foreach (GameObject glowOn in GlowOn)
        {
            glowOn.SetActive(false);
        }
        
        SpirtVolume.SetActive(false);
        
        //_material = GetComponent<Renderer>().material;
        
        isSpiritVisionOn = false;

        //player = GameObject.FindGameObjectWithTag("Player");
 
        _wayfindController = this.GetComponent<WayfindController>();

    }
    
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && isSpiritVisionOn == false && _wayfindController.isWayfindingOn == false)
        {

            foreach (Material matt in MaterialList)
            {

                //Material _material = seeThrough.GetComponent<Renderer>().material;
                
                matt.SetFloat(Opacity,0.5f);

            }
            
            foreach (GameObject glowOn in GlowOn)
            {

                glowOn.SetActive(true);

            }
            
            foreach (GameObject glowOff in GlowOff)
            {

                glowOff.SetActive(false);

            }
            
            SpirtVolume.SetActive(true);
            
            //_material.SetFloat(Opacity,0.5f);

            _wayfindController.isWayfindingOn = true;

            isSpiritVisionOn = true;

        }
        else if  (Input.GetKeyDown(KeyCode.E) && isSpiritVisionOn == true && _wayfindController.isWayfindingOn == true)
        {
            foreach (Material matt in MaterialList)
            {

                //Material _material = seeThrough.GetComponent<Renderer>().material;
                
                matt.SetFloat(Opacity,0f);

            }
            
            foreach (GameObject glowOn in GlowOn)
            {

                glowOn.SetActive(false);

            }
            
            foreach (GameObject glowOff in GlowOff)
            {

                glowOff.SetActive(true);

            }
            
            SpirtVolume.SetActive(false);
            
            isSpiritVisionOn = false;
            
            _wayfindController.isWayfindingOn = false;
            
        }
       
    }
  
}
