using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstrateToIncubator : MonoBehaviour

{
    MushroomManager2 shroom;
    string shroomName;

    void Start()
    {
        shroom = FindObjectOfType<MushroomManager2>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Substrate"))
        {
            shroomName = other.name;
            shroom.AddMushroom(shroomName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("Substrate"))
        {
            shroomName = other.name;
            shroom.StopMushroom(shroomName);
        }
        // other.gameObject.tag = "Fungi";
    }
}

