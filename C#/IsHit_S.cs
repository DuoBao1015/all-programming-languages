using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHit_S : MonoBehaviour {

    public Color originalColorVar;
    /*[HideInInspector]
    public bool isBack = false;
    [HideInInspector]
    public float moveSpeed = 4.5f;*/
    //private Vector3 startPos;

    //for LERP:
    //public Transform cubeTransform;
    //public Transform handTransfrom; //or the position where we want the cube to stop. 

    //public float lerpPercentage; // Value of 1 seems like it would work. Can be played around with.
    void Start ()
    {
        //We are storing the original color of the gameobject to which this script is attached
        originalColorVar = transform.GetComponent<Renderer>().material.color;
        //startPos = transform.position;
    }
    private void Update()
    {
        /*
        if (isBack)
        {
            
            if(Vector3.Distance(transform.position, startPos) > 0)
            {
                transform.Translate((startPos - transform.position)* moveSpeed*Time.deltaTime);
                //transform.position = Vector3.Lerp(cubeTransform.position, handTransfrom.position, lerpPercentage); //where to use???
            }
            else
            {
                
            }
            
        }*/
        
    }
}

