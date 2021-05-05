using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Wayfind2 : MonoBehaviour
{

    public List<GameObject> Collectable = new List<GameObject>();
    
    //public List<GameObject> Doorway = new List<GameObject>();

    private GameObject player;

    public ParticleSystem wind;
    
    private GameObject nearestCollectable;

    private float nearestDistance;
    
    public float speed = 1f;

    private bool isWindActive;

    public GameObject WindONText;
    public GameObject WindOffText;


    
    private WayfindController _wayfindController;


    private void Start()
    {
        
        Collectable.AddRange(GameObject.FindGameObjectsWithTag("pickup"));
        
        Collectable.AddRange(GameObject.FindGameObjectsWithTag("Door"));
        
        _wayfindController = this.GetComponent<WayfindController>();

        player = this.gameObject;

        isWindActive = false;
        wind.Stop();
        
        WindONText.SetActive(false);
        WindOffText.SetActive(true);
    

    }


    void Update()
    {
        nearestDistance = float.MaxValue;
        nearestCollectable = null;

        if (Collectable.Count > 0)
        {

            foreach (GameObject collectable in Collectable)
            {

                if (collectable != null)
                {
                    float distance = Vector3.Distance(player.transform.position, collectable.transform.position);

                    if (distance < nearestDistance)
                    {
                        nearestDistance = Vector3.Distance(player.transform.position, collectable.transform.position);
                        nearestCollectable = collectable;
                    }
                }

            }

         //   Debug.DrawLine(player.transform.position, nearestCollectable.transform.position, new Color(1f, 0f, 0.87f));

            Vector3 rotateDirection = nearestCollectable.transform.position - wind.transform.position;

            float singleStep = speed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, rotateDirection, singleStep, 0f);

            wind.transform.rotation = Quaternion.LookRotation(newDirection);
            
            
                
        }
        else if (Collectable.Count < 1)
        {
            wind.Stop();
        }
        
        if (Input.GetKeyDown(KeyCode.R) && _wayfindController.isWayfindingOn == false)
        {
           wind.Play();
           
           _wayfindController.isWayfindingOn = true;
           isWindActive = true;
           //isBeaconActive = false;
           //isSpiritVisionOn = false;
           
           WindONText.SetActive(true);
           WindOffText.SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.R) && isWindActive && _wayfindController.isWayfindingOn == true)
        {
            
            wind.Stop();
            
            _wayfindController.isWayfindingOn = false;
            
            isWindActive = false;
            //isBeaconActive = false;
            //isSpiritVisionOn = false;
            
            WindONText.SetActive(false);
            WindOffText.SetActive(true);
            
        }



    }
    
}
