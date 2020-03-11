using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{   
    public GameObject ThirdPersonCam;//third person camera
    public GameObject FirstPersonCam;//first person camera

    bool isColliding = false;//if the robot is in position to switch camera
    public int CamMode;//first or third person

    void Start()
    {
        FirstPersonCam.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("colliding");
        if(other.tag == "FPPosition")//if in correct position
        {
            isColliding = true;//set camera switch to be enabled
            Debug.Log("FPPosition");
        }
    }

    void OnTriggerExit(Collider other)//left position
    {
        Debug.Log("exited");
        if(other.tag == "FPPosition")
        {
            isColliding = false;//set camera switch to be disabled
        }
    }

    void Update()
    {
        if(isColliding == true)
        {
            if(Input.GetButtonDown("Camera"))
            {
                Debug.Log("In position and button pressed");
                if(CamMode == 1)
                {
                CamMode = 0;
                }
                else
                {
                CamMode = 1;
                }
                StartCoroutine (CamChange());
            }
        }        
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds (0.01f);
        if (CamMode == 0)
        {
            ThirdPersonCam.SetActive(true);
            FirstPersonCam.SetActive(false);
            this.gameObject.GetComponent<newMovement>().enabled = true;
        }
        if (CamMode == 1)
        {
            FirstPersonCam.SetActive(true);
            ThirdPersonCam.SetActive(false);
            this.gameObject.GetComponent<newMovement>().enabled = false;
        }
    }
}
