using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonHolder : MonoBehaviour
{
    public Transform firstPersonHoldPosition;

    bool beingHeld = false;

    void PickUp()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = firstPersonHoldPosition.position;
        this.transform.parent = firstPersonHoldPosition;
        Debug.Log("Picked up object");

        GetComponent<RotateObject>().enabled = true;

        beingHeld = true;
    }

    void PutDown()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        Debug.Log("Put down object");

        beingHeld = false;
    }

    private void OnMouseOver() 
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(beingHeld == false)
            {
                PickUp();
            }
            else if(beingHeld == true)
            {
                PutDown();
            }
            else
            {
                Debug.Log("yo shit broke");
            }
        }        
    }
}//class
