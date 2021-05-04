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

    private WayfindController _wayfindController;
  
    void Start()
    {
        SpirtVolume.SetActive(false);
        spiritVolumeActive = false;

        //_wayfindController = player.GetComponent<WayfindController>();

        _wayfindController = this.GetComponent<WayfindController>();
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && spiritVolumeActive == false && _wayfindController.isWayfindingOn == false)
        {
            SpirtVolume.SetActive(true);
            spiritVolumeActive = true;
            
            //_wayfindController.isWayfindingOn = true;
          //  thirdPersonCamera.SetActive(false);
           // spiritVisionCamera.SetActive(true);
          //  playerMesh.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && spiritVolumeActive == true && _wayfindController.isWayfindingOn == true)
        {
            SpirtVolume.SetActive(false);
            spiritVolumeActive = false;
            
            //_wayfindController.isWayfindingOn = false;
          //  thirdPersonCamera.SetActive(true);
         //   spiritVisionCamera.SetActive(false);
           // playerMesh.SetActive(true);
        }
    }
}
