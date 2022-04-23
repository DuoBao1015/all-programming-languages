using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    float controllerSpeedHorizontal = 1.5f;
    float controllerSpeedVertical = 1.5f;
    float controllerYaw = 0.0f;
    float controllerPitch = 0.0f; // ^PROF
    public float rotationSpeedMultiplier = 2.0f; //PROF

    Ray ray;

    private bool isGrabbing = false;

    private Transform grabbedTransform;
    private Transform hitTransform;
    
    public Transform handTrans;

    public float zSpeed = 4.5f;
    //public float lerpPercentage;//

    private void Start()
    {
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            controllerYaw += controllerSpeedHorizontal * Input.GetAxis("Mouse X") * rotationSpeedMultiplier;
            controllerPitch += controllerSpeedVertical * Input.GetAxis("Mouse Y") * -rotationSpeedMultiplier;
            transform.localRotation = Quaternion.Euler(controllerPitch, controllerYaw, 0.0f);
        }
       
        
        RaycastHit hitInfo2;
        ray = new Ray(transform.position, transform.forward);

        //HIGLIGHTING
        if (Physics.Raycast(ray, out hitInfo2))
        {
            if (hitInfo2.transform.tag == "Grabbable" && !isGrabbing)
            {
                if (hitTransform != null)
                    SetHighlight(hitTransform, false);

                hitTransform = hitInfo2.transform;
                SetHighlight(hitTransform, true);
            }
            else
            {
                if (hitTransform != null && !isGrabbing)
                    SetHighlight(hitTransform, false);
            }
        }

        else
        {
            if (hitTransform != null && !isGrabbing)
            {
                SetHighlight(hitTransform, false);
            }
        }

        //CUBE PICK UP 

        //RaycastHit hitInfo; //necessary???? 

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            
            if (Physics.Raycast(ray, out hitInfo2))
            {
                if (hitInfo2.transform.tag == "Grabbable") // New
                {
                    isGrabbing = true;
                    grabbedTransform = hitInfo2.transform;
                    grabbedTransform.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedTransform.GetComponent<Rigidbody>().useGravity = false;
                    grabbedTransform.parent = transform;                  
                   
                    //StartCoroutine("CubeMovingToHand");
                }
            }

        }

        if (isGrabbing && Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartCoroutine("MovingCube");
            /*
            if (grabbedTransform != null )
            {
                grabbedTransform.GetComponent<Rigidbody>().isKinematic = true;
                grabbedTransform.GetComponent<Rigidbody>().useGravity = true;
                grabbedTransform.parent = null;
            }*/

            float xPos = grabbedTransform.position.x;
            float yPos = grabbedTransform.position.y;
            if (Vector3.Distance(handTrans.position, grabbedTransform.position) < 1f)
            {
                grabbedTransform.Translate(grabbedTransform.forward * zSpeed * Time.deltaTime);
            }

            isGrabbing = false;
        }

        //Moving the cube towards the "hand": 
        if (isGrabbing)
        {

            if (Vector3.Distance(handTrans.position, grabbedTransform.position) > 0.5f)
            {
                grabbedTransform.Translate((handTrans.position - grabbedTransform.position).normalized * zSpeed * Time.deltaTime);
            }

        }

 

        //Highlight Function:
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

    }

    IEnumerator MovingCube()
    {


        yield return new WaitForSeconds(1f);

        if (grabbedTransform != null)
        {
            grabbedTransform.GetComponent<Rigidbody>().isKinematic = true;
            grabbedTransform.GetComponent<Rigidbody>().useGravity = true;
            grabbedTransform.parent = null;
        }
    }
}
