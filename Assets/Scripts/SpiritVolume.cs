using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritVolume : MonoBehaviour
{
    public GameObject SpirtVolume;
    private bool spiritVolumeActive;
    public GameObject thirdPersonCamera;
    public GameObject spiritVisionCamera;
    //public GameObject playerMesh;
  
    void Start()
    {
        SpirtVolume.SetActive(false);
        spiritVolumeActive = false;
        
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && spiritVolumeActive == false)
        {
            SpirtVolume.SetActive(true);
            spiritVolumeActive = true;
          //  thirdPersonCamera.SetActive(false);
           // spiritVisionCamera.SetActive(true);
          //  playerMesh.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && spiritVolumeActive == true)
        {
            SpirtVolume.SetActive(false);
            spiritVolumeActive = false;
          //  thirdPersonCamera.SetActive(true);
         //   spiritVisionCamera.SetActive(false);
           // playerMesh.SetActive(true);
        }
    }
}
