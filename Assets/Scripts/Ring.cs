using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ring : MonoBehaviour
{
    [SerializeField] float moveSpeed; 
    [SerializeField] ParticleSystem deadParticle;
    Vector3 defaultScale;
    float scene;




    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        scene = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButton(0))
        {
            if(transform.localScale.x < Recognizer.newScale.x)
            {
                Debug.Log("die");
                Die();
            }
            else
            {
                Debug.Log("Enlarge");
                transform.localScale = Vector3.Lerp(transform.localScale, Recognizer.newScale,0.5f);            
            }
        }
        else
        {
            Debug.Log("Shrink");
            transform.localScale = Vector3.Lerp(transform.localScale,defaultScale,0.5f);
        }

        Mover();
        deathHandler();
    }

    public void deathHandler()
    {
        if(Collider.isTouchingObstacle ==true)
        {
            Die();
        }    
    }

    public void Finish()
    {
        GetComponentInChildren<MeshRenderer>().enabled = false;
        FindObjectOfType<CameraFollow>().enabled = false;
        Destroy(gameObject,1);
    }

    private void Die()
    {
        if(!deadParticle.isPlaying)
        {
            deadParticle.Play();
        }
        GetComponentInChildren<MeshRenderer>().enabled = false;
        FindObjectOfType<CameraFollow>().enabled = false;
        Destroy(gameObject,1);
    }

    void Mover()
    {
        transform.Translate(0,0,moveSpeed*Time.deltaTime);
    }


}
