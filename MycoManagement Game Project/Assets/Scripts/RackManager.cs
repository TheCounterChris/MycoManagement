using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackManager : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();

    GameObject availableSlot;

    bool dishColliding = false;
    bool bodyColliding = false;
    public GameObject thirdPersonHoldPos;

    GameObject dish;

    

    void Update()
    {
        if(dishColliding == true)
        {
            if(Input.GetKeyDown("r"))
            {
                checkAvailability();
                dish.gameObject.transform.position = availableSlot.transform.position;
                dish.gameObject.transform.parent = availableSlot.transform;
                dish.gameObject.transform.rotation = Quaternion.identity;
                dish.gameObject.GetComponent<PickUp>().enabled = false;
                dishColliding = false;
            }
        }


        if(bodyColliding == true)
        {
            if(thirdPersonHoldPos.transform.childCount == 0)
            {
                Debug.Log("Press E");
                if(Input.GetKeyDown("t"))
                {
                    Debug.Log("key pressed");
                    for(int i = 0; i < slots.Count; i++)
                    {
                        Debug.Log("recursive process");
                        if(slots[i].transform.childCount > 0)
                        {
                            GameObject firstDish = slots[i].transform.GetChild(0).gameObject;
                            firstDish.transform.position = thirdPersonHoldPos.transform.position;
                            firstDish.transform.parent = thirdPersonHoldPos.transform;
                            firstDish.gameObject.GetComponent<PickUp>().enabled = true;
                            Debug.Log("picked up object");

                            break;
                        }
                    }
                }
            }
        }        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Dish")
        {
            Debug.Log("Dish colliding");
            dishColliding = true;
            dish = other.gameObject;            
        }

        if(other.tag == "PickUp")
        {
            Debug.Log("Robot in place");
            bodyColliding = true;            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Dish")
        {
            Debug.Log("No More Dish");
            dishColliding = false;
        }

        if(other.tag == "PickUp")
        {
            Debug.Log("Robot not in place :(");
            bodyColliding = false;
        }
    }

    void checkAvailability()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if(slots[i].transform.childCount < 1)
            {
                availableSlot = slots[i];
                break;
            }
        }
    }
}
