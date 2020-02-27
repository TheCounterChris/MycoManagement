using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwitch : MonoBehaviour
{
    public GameObject CameraMonitor;
    public Collider CharacterBody;
    //public Canvas InteractionUI;
    public GameObject GUI;

    void Start()
    {
        CameraMonitor.SetActive(false);     
    }
    void OnTriggerEnter(Collider other)
    {
        CameraMonitor.SetActive(true);
        GUI.SetActive(true);     
    }

    void OnTriggerExit()
    {
        CameraMonitor.SetActive(false);
        GUI.SetActive(false);
 
    }
    void Update()
    {
         if(Input.GetButtonDown ("Interact"))
         {
             GUI.SetActive(false);
         }
    }
}
