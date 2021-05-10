using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{


    public GameObject Dialogue;
    private bool areWeTalking;
   // public Dialogue dialogue;
    public GameObject QToTalk;
    
    void Start()
    {
        Dialogue.SetActive(false);
        areWeTalking = false;
        QToTalk.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collector"))
        {
            QToTalk.SetActive(true);
            areWeTalking = true;
            
            

        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.Q) && areWeTalking == true)
        {
            Dialogue.SetActive(true);
          //  FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            QToTalk.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("collector"))
        {
            Dialogue.SetActive(false);
            areWeTalking = false;
            QToTalk.SetActive(false);
            
        }
        
    }
}
