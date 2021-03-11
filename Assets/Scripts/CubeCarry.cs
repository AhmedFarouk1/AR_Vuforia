using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCarry : MonoBehaviour
{

     void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Cube")
        {
            
            collision.transform.parent = transform ;
          
        }
    }
}
