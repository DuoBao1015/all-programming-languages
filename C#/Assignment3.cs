using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Assignment3 : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }







    //*****************************Given SetHighlight Method, Not To Be Changed******************************//
    //************ This method takes in a transform and a boolean to highlight or dim the GameObject*********//
    void SetHighlight(Transform t, bool highlight)
    {
        if (highlight)
        {
            t.GetComponent<Renderer>().material.color = Color.cyan;
            t.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineAll;
            transform.GetComponent<LineRenderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        }
        else
        {
            t.GetComponent<Renderer>().material.color = t.GetComponent<IsHit_S>().originalColorVar;
            t.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
            transform.GetComponent<LineRenderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
        }
    }
    //*****************************End of The Given SetHighlight Method**************************************//
}
