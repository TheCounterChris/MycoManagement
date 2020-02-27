using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GillExtraction : MonoBehaviour
{
    public GameObject gills;
    Quaternion gillsRotation;
    public GameObject[] cutPoints = new GameObject[8];
    public GameObject tablePlace;

    Transform trashCan;

    int numCuts = 0;

    // Start is called before the first frame update
    void Start()
    {
        trashCan = GameObject.Find("Trashcan").transform;
        gillsRotation = gills.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // if(numCuts >= 4)
        // {
        //     Debug.Log("They all got cut yo");
        //     gills.transform.parent = null;
        // }
    }

    public void UpdateCut()
    {
        numCuts++;
        Debug.Log("Number of cuts: " + numCuts);

        if(numCuts >= 4)
        {
            Debug.Log("They all got cut mufu");
            gills.transform.parent = null;
            
            gameObject.transform.position = trashCan.position;
            gameObject.transform.parent = null;
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<RotateObject>().enabled = false;

            gills.transform.position = tablePlace.transform.position;
            gills.transform.rotation = gillsRotation;
            //gills.AddComponent<Rigidbody>();
        }
    }
}//class
