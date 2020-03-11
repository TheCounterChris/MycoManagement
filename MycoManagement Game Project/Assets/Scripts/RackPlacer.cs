using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackPlacer : MonoBehaviour
{
    
    public List<GameObject> slots = new List<GameObject>();

    GameObject availableSlot;
    public GameObject substrateSlot;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Rack")
        {
            Debug.Log("RACK!! RACK !! RACK!!");
            //gameObject.transform.parent = null;
            checkAvailability();
            gameObject.transform.position = availableSlot.transform.position;
            gameObject.transform.parent = availableSlot.transform;
            }
        
        if(other.tag == "SubstrateStation")
        {
            Debug.Log("Substrate Station");

            if(substrateSlot.transform.childCount == 0)
            {
                gameObject.transform.position = substrateSlot.transform.position;
                gameObject.transform.parent = substrateSlot.transform;
            }
            else
            {
                Debug.Log("No space on counter");
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Rack")
        {
            Debug.Log("NOT RACK !! NOT RACK !! NOT RACK!!");
        }

        if(other.tag == "SubstrateStation")
        {
            Debug.Log("NO MORE SUBSTRATE");
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
