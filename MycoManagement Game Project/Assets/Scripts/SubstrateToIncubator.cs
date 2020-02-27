using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstrateToIncubator : MonoBehaviour

{

    MushroomManager shroom;

    string shroomName;

    void Start() {
        shroom = FindObjectOfType<MushroomManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fungi"))
        {
            Debug.Log("collision detected");
            shroomName = other.name;
            shroom.AddMushroom(shroomName);
        }
    }
}

