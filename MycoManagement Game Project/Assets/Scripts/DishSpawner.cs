using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishSpawner : MonoBehaviour
{

    public GameObject dish;

    public Transform spawnerPoint;

    bool colliding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(colliding)
        {
            if(Input.GetKeyDown("m"))
            {
                Instantiate(dish, spawnerPoint);
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            colliding = true;
            Debug.Log("Colliding");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            colliding = false;
        }
    }
}
