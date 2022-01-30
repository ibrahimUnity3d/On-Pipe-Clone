using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recognizer : MonoBehaviour
{
    public static Vector3 newScale;
    float x;

     void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.tag == "Cylinder")
        {
            x = other.gameObject.transform.localScale.x;
            newScale.x=x;
            newScale.y=x;
            newScale.z=5;            
        }
    }
}
