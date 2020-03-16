using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstratePlanter : MonoBehaviour
{

    GameObject emptyPot;
    GameObject plantedPot;

    public Transform slot;

    int buttonPressed = 0;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        emptyPot = this.gameObject.transform.GetChild(0).gameObject;
        plantedPot = this.gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(slot.childCount > 0)
        {
            timer += Time.deltaTime;

            if(timer <= 5)
            {
                if(Input.GetKeyDown("space"))
                {
                    buttonPressed += 1;
                }
            }
            else
            {
                timer = 0;
                buttonPressed = 0;
            }

            if(buttonPressed >= 10)
            {
                emptyPot.SetActive(false);
                plantedPot.SetActive(true);

                Destroy(slot.GetChild(0).gameObject);
            }                  
        }        
    }
}
