using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstrateToGenerator : MonoBehaviour

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
            // Debug.Log(shroom.);
            shroom.RemoveMushroom(shroomName);
            Destroy(other.gameObject);
        }
    }
}

