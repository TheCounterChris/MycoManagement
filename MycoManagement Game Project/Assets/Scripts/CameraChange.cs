using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdPersonCam;
    public GameObject FirstPersonCam;
    public bool CamSwitch = false; //to activate the ability to switch cameras when colliding with specific triggers.
    public int CamMode;
    public Collider CharacterBody;
   public Camera MainCam;
   

    // Update is called once per frame
    void Start()
    {
        MainCam = Camera.main;
        FirstPersonCam.SetActive(false);
    }
    void Update()
    {
      if(Input.GetButtonDown ("Interact")) {
          if (CamMode == 1) {
              CamMode = 0;
          } else {
              CamMode += 1;
          }
          StartCoroutine (CamChange ());
      }
IEnumerator CamChange() {
    yield return new WaitForSeconds (0.01f);
    if (CamMode == 0) {
        ThirdPersonCam.SetActive(true);
        FirstPersonCam.SetActive(false);
    }
    if (CamMode == 1) {
        FirstPersonCam.SetActive(true);
        ThirdPersonCam.SetActive(false);

    }

}

    }
}
