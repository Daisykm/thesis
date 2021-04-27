using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Wayfind2 : MonoBehaviour
{

    public List<GameObject> Collectable = new List<GameObject>();

    private GameObject player;
    
    private GameObject nearestCollectable;

    private float nearestDistance;

    private void Start()
    {
        
        Collectable.AddRange(GameObject.FindGameObjectsWithTag("pickup"));

        player = this.gameObject;

    }


    void Update()
    {
        
        nearestDistance = float.MaxValue;
        nearestCollectable = null;

        if (Collectable.Count > 0)
        {

            foreach (GameObject collectable in Collectable)
            {

                // if (collectable == null)
                //{
                //Collectable.Remove(collectable);
                //}

                float distance = Vector3.Distance(player.transform.position, collectable.transform.position);

                if (distance < nearestDistance)
                {
                    nearestDistance = Vector3.Distance(player.transform.position, collectable.transform.position);
                    nearestCollectable = collectable;
                }

            }


            Debug.DrawLine(player.transform.position, nearestCollectable.transform.position, new Color(1f, 0f, 0.87f));

        }

    }
    
}
