using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakLights : MonoBehaviour
{
    //script for break lights of the blue car
    Renderer break_renderer;

    private void Start()
    {
        //Calls renderer
        break_renderer = GetComponent<Renderer>();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            break_renderer.material.color = Color.red;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            break_renderer.material.color = Color.gray;

        }

    }
}
