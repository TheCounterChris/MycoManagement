using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstratePlanter : MonoBehaviour
{

    GameObject emptyBag;
    GameObject halfBag;
    GameObject inflatedBag;

    int buttonPressed = 0;
    public int timeLimit = 5;
    public int buttonGoal = 10;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        emptyBag = this.gameObject.transform.GetChild(0).gameObject;
        halfBag = this.gameObject.transform.GetChild(1).gameObject;
        inflatedBag = this.gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(halfBag.activeSelf)
        {
            timer += Time.deltaTime;

            if(timer <= timeLimit)
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

            if(buttonPressed >= buttonGoal)
            {
                halfBag.SetActive(false);
                inflatedBag.SetActive(true);
            }                  
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dish")
        {
            emptyBag.SetActive(false);
            halfBag.SetActive(true);
            
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Not a dish");
        }
    }
}
