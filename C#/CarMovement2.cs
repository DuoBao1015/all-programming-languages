using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement2 : MonoBehaviour
{
    //car movement for white car
    public int speed2;
    bool movingLeft = true;
    private void Start()
    {

    }
    void Update()
    {
       
        if (movingLeft)
        {
            this.transform.Translate(Vector3.left * speed2 * Time.deltaTime, Space.Self);
            if (this.transform.position.x < -100)
            {
                movingLeft = false;
                transform.rotation = Quaternion.Euler(0, 180, 0);//IT FLIPS //IT FLIPS the the car does not move it

            }
        }
        else
        {
            transform.Translate(Vector3.left * speed2 * Time.deltaTime, Space.Self);
            if (this.transform.position.x >= 100)
            {
                movingLeft = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);//IT FLIPS
            }
        }
        StopCar();
                    
    }

    //function for stoping the car
    void StopCar()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed2 = 0;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed2 = 6;
        }
    }


}
