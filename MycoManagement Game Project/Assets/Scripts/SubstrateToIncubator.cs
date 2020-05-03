using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstrateToIncubator : MonoBehaviour

{
    MushroomManager2 shroom;
    string shroomName;

    public List<GameObject> incSlots = new List<GameObject>();
    GameObject availableSlot;

    GameObject subBag;

    bool playerReady = false;
    bool bagReady = false;

    public GameObject thirdPersonHoldPos;

    void Start()
    {
        shroom = FindObjectOfType<MushroomManager2>();
    }

    void Update()
    {
        if(bagReady == true)
        {
            if(Input.GetKeyDown("r"))
            {
                checkAvailability();
                subBag.gameObject.transform.position = availableSlot.transform.position;
                subBag.gameObject.transform.parent = availableSlot.transform;
                //subBag.gameObject.transform.rotation = Quaternion.identity;
                subBag.gameObject.GetComponent<PickUp>().enabled = false;
                bagReady = false;
            }
        }

        if(playerReady)
        {
            if(thirdPersonHoldPos.transform.childCount == 0)
            {
                Debug.Log("Press T");
                if(Input.GetKeyDown("t"))
                {
                    Debug.Log("key pressed");
                    for(int i = 0; i < incSlots.Count; i++)
                    {
                        Debug.Log("recursive process");
                        if(incSlots[i].transform.childCount > 0)
                        {
                            GameObject firstBag = incSlots[i].transform.GetChild(0).gameObject;
                            firstBag.transform.position = thirdPersonHoldPos.transform.position;
                            firstBag.transform.parent = thirdPersonHoldPos.transform;
                            firstBag.gameObject.GetComponent<PickUp>().enabled = true;
                            Debug.Log("picked up object");

                            break;
                        }
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Substrate"))
        {
            shroomName = other.name;
            shroom.AddMushroom(shroomName);

            subBag = other.gameObject;

            bagReady = true;

            checkAvailability();
        }

        if(other.tag.Equals("Player"))
        {
            playerReady = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Substrate"))
        {
            shroomName = other.name;
            shroom.StopMushroom(shroomName);

            bagReady = false;
        }


        if(other.tag.Equals("Player"))
        {
            playerReady = false;
        }
    }

    void checkAvailability()
    {
        for(int i = 0; i < incSlots.Count; i++)
        {
            if(incSlots[i].transform.childCount < 1)
            {
                availableSlot = incSlots[i];
                break;
            }
        }
    }
}

