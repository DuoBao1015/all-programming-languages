using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//********************************************************************************//
//******THIS SCRIPT EMULATES CONTROLLER ROTATION SIMILAR TO A VR CONTROLLER*******//
//********************************************************************************//

//The controller can be rotated by pressing the C key and moving the mouse in Play Mode

public class EmulateControllerRotation : MonoBehaviour
{
    float controllerSpeedHorizontal = 1.5f;
    float controllerSpeedVertical = 1.5f;
    float controllerYaw = 0.0f;
    float controllerPitch = 0.0f;

    private bool isGrabbing = false;
    private Transform grabbedTransform;
    public float zSpeed = 4.5f;
    public float rotationSpeedMultiplier = 2.0f;


    public float speed = 2f;

    public Transform handTrans; //
    private Transform hisTransform;
    private Vector3 startPos; //
    public float lerpPercentage;//

    private void Start()
    {
    }
    Ray ray;
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
        if (Physics.Raycast(ray, out hitInfo2))
        {
            if (hitInfo2.transform.tag == "Grabbable" && !isGrabbing)
            {
                if (hisTransform != null)
                    SetHighlight(hisTransform, false);

                hisTransform = hitInfo2.transform;
                SetHighlight(hisTransform, true);
            }
            else
            {
                if (hisTransform != null && !isGrabbing)
                    SetHighlight(hisTransform, false);
            }
        }

        else
        {
            if (hisTransform != null && !isGrabbing)
            {
                SetHighlight(hisTransform, false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) // New / GetKeyDown
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.tag == "Grabbable") // New
                {
                    isGrabbing = true;
                    grabbedTransform = hitInfo.transform;
                    grabbedTransform.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedTransform.GetComponent<Rigidbody>().useGravity = false;

                    grabbedTransform.position = handTrans.position;
                    
                    
                    //grabbedTransform.position = Vector3.Lerp(grabbedTransform.position, handTrans.position, lerpPercentage); ////////// 
                    /*
                    if (!isGrabbing)
                    {
                        startPos = hitInfo.transform.position;
                        isGrabbing = true;
                        grabbedTransform = hitInfo.transform;
                        //grabbedTransform.GetComponent<Rigidbody>().useGravity = false;
                        grabbedTransform.GetComponent<IsHit_S>().isBack = false;
                        grabbedTransform.GetComponent<IsHit_S>().moveSpeed = zSpeed;
                    }*/
                }
            }
            /*
            if (isGrabbing && Input.GetKeyUp(KeyCode.Mouse0)) //New
            {
                if (grabbedTransform != null)
                {
                    grabbedTransform.GetComponent<Rigidbody>().isKinematic = false;
                    grabbedTransform.GetComponent<Rigidbody>().useGravity = true;
                    //grabbedTransform.GetComponent<IsHit_S>().isBack = true;
                    //grabbedTransform = null;
                    grabbedTransform.parent = null;
                }
                isGrabbing = false;
            }
            */

            
            if (isGrabbing)
            {

                if (Vector3.Distance(handTrans.position, grabbedTransform.position) > 0.5f)
                {
                    grabbedTransform.Translate((handTrans.position - grabbedTransform.position).normalized * zSpeed * Time.deltaTime);
                }
                Debug.DrawLine(handTrans.position, grabbedTransform.position, Color.red);
            }

        }


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
}
