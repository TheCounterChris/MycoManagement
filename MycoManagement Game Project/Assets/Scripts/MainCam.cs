using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main; //to set the third person camera as the first camera that shows up.
    }
}


