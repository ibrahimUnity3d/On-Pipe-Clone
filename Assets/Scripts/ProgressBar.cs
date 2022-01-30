using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ProgressBar : MonoBehaviour
{
    public static float progressPercent;
    Ring ring;
    
    float currentProgress,startPoint,lenght;
    bool isFinished;
    

    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        ring = FindObjectOfType<Ring>();
        startPoint= transform.position.y;
        lenght = 74;
    }

    // Update is called once per frame
    void Update()
    {
       currentProgress= transform.position.y - startPoint;
       progressPercent = currentProgress/lenght;
       
       if(progressPercent>=1 && isFinished == false)
       {
           ring.Finish();
           isFinished= true;
       }

    }
}
