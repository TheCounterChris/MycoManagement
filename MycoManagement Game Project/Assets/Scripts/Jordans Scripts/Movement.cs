using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float movementSpeed;

    

    public float fuel = 100;

    public Text FuelText;
    public GameObject Prompt;
    public Image FuelImage;

    public bool GetFuel = false;
        // defining the fuel state
    public bool HasCollided = false;
        //defining the collision state 
    // Use this for initialization
    void Start()
    {
        Prompt.SetActive(false);
            // setting the prompt text to inactive
    }
    void Update()
    {
        if (GetFuel == false)
        {
            if (HasCollided == true)
            // if the collider is activate and player has low fuel
            {
                if (Input.GetKeyDown("e"))
                {

                    UpdateFuelGain();
                    //calling updatefuelgain function
                }
            }
        }
        else
        {
            if (Input.GetKeyDown("e"))
            //stating that nothing will happen if  pressed outwith trigger
            {

            }
        }
    }
    //Update is called once per frame
    void FixedUpdate()
    {



        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w") )
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
            
            fuel = Mathf.Clamp(fuel, 0f, 100f) - Time.deltaTime;
                //setting an upper and lower limit for the fuel consumption and then depleting fuel amount
        }
        else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift) )
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
           
            fuel = Mathf.Clamp(fuel, 0f, 100f) - Time.deltaTime;

        }
        else if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
           
            fuel = Mathf.Clamp(fuel, 0f, 100f) - Time.deltaTime;

        }

        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
           
            fuel = Mathf.Clamp(fuel, 0f, 100f) - Time.deltaTime;
           

        }
        else if (Input.GetKey("d") && !Input.GetKey("a") )
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
           
            fuel = Mathf.Clamp(fuel, 0f, 100f) - Time.deltaTime;
            
        }

        UpdateFuelLoss();

    }
    public void UpdateFuelLoss()
    {
        FuelImage.fillAmount = fuel/100;
            //dividing fuel by 100 as fill amount is set to 1
        FuelText.text = "Current fuel" + fuel;
             //linking fuel to numerical value of fuel
             
    }
    public void UpdateFuelGain()
    {
        FuelImage.fillAmount = fuel;
        FuelText.text = "Current fuel" + fuel;
        GetFuel = true;
        Debug.Log("is charging");
        fuel = 100;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Generator")
            //getting generator tag
        {
               
            Prompt.SetActive(true);
                //Text GamObject is activated
            Debug.Log("entered charging port");
            HasCollided = true; 
                // Trigger has been activated
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Generator")
            //getting generator tag 
        {
            Debug.Log("has left charging port");
            HasCollided = false;
            GetFuel = false;
                //Trigger has been deactivated
            Prompt.SetActive(false);
                //Text GameObject has been deactivated

        }
    }
}
