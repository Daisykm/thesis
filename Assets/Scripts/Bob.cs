using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{


    public GameObject water;

    public float speed;
    
   

    
    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 2 - 1;
        water.transform.position = new Vector3(0, y, 0);
    }
}
