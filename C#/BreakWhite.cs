using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWhite : MonoBehaviour
{
    //script for break lights of the blue car
    Renderer break_renderer2;

    private void Start()
    {
        break_renderer2 = GetComponent<Renderer>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            break_renderer2.material.color = Color.red;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            break_renderer2.material.color = Color.gray;

        }

    }
}
