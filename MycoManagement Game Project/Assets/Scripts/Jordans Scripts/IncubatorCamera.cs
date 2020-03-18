using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncubatorCamera : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public bool isCam1Active;

    public bool isCam2Active;
    // Start is called before the first frame update
    void Start()
    {
        isCam1Active = true;
        isCam2Active = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isCam1Active == true)
        {
            
            ActivateCam2();
        }

        if (Input.GetKeyUp(KeyCode.Space) && isCam2Active == true)
        {
          
            ActivateCam1();

        }

    }
    public void ActivateCam2()
    {
        isCam2Active = true;
        Cam1.SetActive(false);
        Cam2.SetActive(true);
        Debug.Log("Cam 2");
    }
    public void ActivateCam1()
    {  
        isCam1Active= true;
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Debug.Log("Cam 2");
    }

    // yield return null;
}
      




