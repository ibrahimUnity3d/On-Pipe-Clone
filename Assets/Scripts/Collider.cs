using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    [SerializeField] ParticleSystem cornParticle;
    public static bool isTouchingObstacle;
    public static Vector3 otherScale;
    Rigidbody cornRB;

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Obstacle")
        {
        isTouchingObstacle = true;
        }
        
        else if(other.gameObject.tag == "Corn")
        {
            if(!cornParticle.isPlaying)
            {
                cornParticle.Play();
            }
            cornRB= other.gameObject.GetComponent<Rigidbody>();
            cornRB.constraints=RigidbodyConstraints.None;
            Destroy(other.gameObject,3f);
            Scorer.score++;
        }
    }   
   
}

