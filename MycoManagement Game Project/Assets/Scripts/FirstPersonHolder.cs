using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS ATTACHED TO THE MUSHROOM OR ANY OBJECT THAT YOU WANT TO HOLD IN FIRST PERSON VIEW
public class FirstPersonHolder : MonoBehaviour
{
    //public Transform firstPersonHoldPosition;
    Transform firstPersonHoldPosition;//The position where the object will be held

    bool beingHeld = false;//if object is currently being held

    void Start()
    {
        firstPersonHoldPosition = GameObject.Find("FirstPersHoldPos").transform;//get the holfing position
    }

    void PickUp()//pick up the object
    {
        GetComponent<Rigidbody>().useGravity = false;//turn off gravity
        this.transform.position = firstPersonHoldPosition.position;//move to holding position
        this.transform.parent = firstPersonHoldPosition;//set the parent to the holding position
        Debug.Log("Picked up object");//print

        GetComponent<RotateObject>().enabled = true;//set the rotate object script to active

        beingHeld = true;//object is being held
    }

    void PutDown()//put down the object
    {
        this.transform.parent = null;//remove the parent of the object
        GetComponent<Rigidbody>().useGravity = true;//turn on gravity
        Debug.Log("Put down object");//print

        beingHeld = false;//object is not being held
    }

    private void OnMouseOver()//if the mouse is over the object
    {
        if(Input.GetMouseButtonDown(1))//if the right mouse button is held
        {
            if(beingHeld == false)//if it is not previously held
            {
                PickUp();//pick up th object
            }
            else if(beingHeld == true)
            {
                PutDown();//put down the object
            }
            else
            {
                Debug.Log("yo shit broke");//something went wrong
            }
        }        
    }
}//class
