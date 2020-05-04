using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Transform thirdPersHoldPos;//hand position
    Transform firstPersHoldPos;//first person hold position

    GameObject pickUpObject;
    bool colliding = false;//if hand is colliding with object
    bool pickedUp = false;//if hand is already holding something

    void Start()
    {

        pickUpObject = this.gameObject;
        thirdPersHoldPos = GameObject.Find("ThirdPersHoldPos").transform;
        // Debug.Log("HAND: " + thirdPersHoldPos);

        firstPersHoldPos = GameObject.Find("FirstPersHoldPos").transform;
        // Debug.Log("FIRST PERS HOLD POS: " + firstPersHoldPos);
    }

    void Update()
    {
        if(thirdPersHoldPos.childCount == 0)//if the hand is not holding something
        {
            pickedUp = false;//not picked up, empty hand
        }

        if(thirdPersHoldPos.childCount > 0)//if the hand is holding something
        {
            pickedUp = true;//picked up, full hand
        }


        
        if(pickedUp == false)//not holding anything
        {
            if(colliding == true)//something to pick up
            {
                // Debug.Log("No held item and in position to pick up");
                if(Input.GetButtonDown("Interact"))//get input key
                {
                    // Debug.Log("Pressed button to pick up object");
                    PickUpObject();//pick up the object
                    AkSoundEngine.PostEvent("PickUp", pickUpObject);
                }
            }
            else//not in position to pick up
            {
                if(Input.GetButtonDown("Interact"))//get input key
                {
                    // Debug.Log("Pressed button to pick up object, but not in position to pick up object");
                }
            }
        }
        else if(pickedUp == true)//already holding something
        {
            if(Input.GetButtonDown("Put Down"))//input to put down object
            {
                // Debug.Log("Pressed button to put down object");
                PutDownObject();//put down object
            }
        }
        else//if something went wrong
        {
            if(Input.GetButtonDown("Interact"))
            {
                // Debug.Log("There is no held item");
            }
        }
        
    }

    void PickUpObject()//[pick up]
    {
        if(pickedUp == false)//if not holding anything
        {
            GetComponent<Collider>().isTrigger = true;//turn off collider so it doesn't hit stuff when moving
            GetComponent<Rigidbody>().isKinematic = true;//turn on kinematic just to make sure it doesn't hit stuff when moving        
            GetComponent<Rigidbody>().useGravity = false;//turn off gravity
            this.transform.position = thirdPersHoldPos.position;//move object to hand
            this.transform.parent = thirdPersHoldPos;//parent object to hand so it moves with robot

            pickedUp = true;//object is picked up

            // Debug.Log("Object should be picked up");
        }
    }

    void PutDownObject()//put down
    {
        //if(this.transform.parent == thirdPersHoldPos)//if the object is indeed being held
        //{
            //this.transform.position = firstPersHoldPos.position;//move object infront of player
            //this.transform.rotation = Quaternion.identity;
            this.transform.parent = null;//remove parent
            GetComponent<Collider>().isTrigger = false;//turn on colliders
            GetComponent<Rigidbody>().isKinematic = false;//turn off kinematic
            GetComponent<Rigidbody>().useGravity = true;//turn on gravity

            pickedUp = false;//not being held

            // Debug.Log("Object should be put down");
        
            colliding = false;//no longer colliding
        //}
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PickUp")//if colliding with the pick up space
        {
            // Debug.Log("Entered pick up space");
            colliding = true;//turn on colliding so that it can be picked up
        }
        else{
            // Debug.Log("Entered other collider");
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "PickUp")//left the pick up space
        {
            // Debug.Log("left pick up space");
            colliding = false;//turn off colliding, cannot pe picked up
        }
    }
}
