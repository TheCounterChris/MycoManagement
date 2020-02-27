using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickCameraChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ThirdPersCam;
    public GameObject FirstPersCam;
    public int camMode;

    void Update()
    {
        if(Input.GetButtonDown("Camera"))
        {
            if(camMode == 1)
            {
                camMode = 0;
            }
            else
            {
                camMode = 1;
            }
            StartCoroutine(CamChange());
        }
        
    }

    IEnumerator CamChange()
    {
        yield return new WaitForSeconds (0.01f);
        if(camMode == 0)
        {
            ThirdPersCam.SetActive(true);
            FirstPersCam.SetActive(false);
        }
        if(camMode == 1)
        {
            ThirdPersCam.SetActive(false);
            FirstPersCam.SetActive(true);
        }
    }
}
