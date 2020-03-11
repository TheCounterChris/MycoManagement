using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackDispenser : MonoBehaviour
{
    public GameObject hand;
    public List<GameObject> slots = new List<GameObject>();

    bool colliding;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(colliding == true)
        {
            if(hand.transform.childCount == 0)
            {
                Debug.Log("Press T");
                if(Input.GetKeyDown("t"))
                {
                    Debug.Log("key pressed");
                    for(int i = 0; i < slots.Count; i++)
                    {
                        Debug.Log("recursive process");
                        if(slots[i].transform.childCount > 0)
                        {
                            GameObject firstDish = slots[i].transform.GetChild(0).gameObject;
                            firstDish.transform.position = hand.transform.position;
                            firstDish.transform.parent = hand.transform;
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
        if(other.tag == "PickUp")
        {
            Debug.Log("SWIGNSHJKLABFALSKH");
            colliding = true;            
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "PickUp")
        {
            Debug.Log("QWERTYYUIOP{");
            colliding = false;
        }
    }
}
