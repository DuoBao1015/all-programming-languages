using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{    //car movement for blue car
    public int speed;
    bool movingRight = true;
    
    private void Start()
    {

    }
    void Update()
    {
        
        if (movingRight) 
        {
            this.transform.Translate(this.transform.right * speed * Time.deltaTime, Space.Self);
            if (this.transform.position.x > 100)
            {
                movingRight = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);//IT FLIPS the the car does not move it
                
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
            if (this.transform.position.x <= -100)
            {
                movingRight = true;
                transform.rotation = Quaternion.Euler(0, -180, 0);//IT FLIPS
            }
        }
        StopCar();
    }

    //function for stoping the car
    void StopCar()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 0;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 6;
        }
    }




}
