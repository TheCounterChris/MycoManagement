using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDestroy : MonoBehaviour //script that controls the state changes of the mushrooms as well as how many points they get. They also get affected by temperature through their rate if growth (ROG).
{
    public GameObject State1; //simple game objects that depict each stage of growth through a different model. These will be detroyed throughout the growth process.
    public GameObject State2;
    public GameObject State3;
    public GameObject State4;
    public GameObject State5;
    public GameObject State6;
    public GameObject Particles; //particle effect to show visual signal of when positive growth happens.
    public float MushroomPoints; //value which will change dependent on growth state of mushroom.
    public GameObject Temp; //temperature that affects the speed of growth.
    
    // Start is called before the first frame update
    void Update()
    {    
        Time.timeScale = Temp.GetComponent<Temperature>().ROG; //in the Update so that the temperature can update the ROG into the growth states. 
    }
    void Start()
    {
              
         //Gets the Rate of Growth from the temperature component.
        Time.timeScale = Temp.GetComponent<Temperature>().ROG; 
        State1.SetActive(true); //Sets the first active mushroom state.
        State2.SetActive(false); //All other states start as false.
        State3.SetActive(false);
        State4.SetActive(false);
        State5.SetActive(false);
        State6.SetActive(false);
        Particles.SetActive(false);

        Invoke("Change1", 5.0f); //the times for each cstate change to happen within. These can be changed for each breed. 
        Invoke("Change2", 10.0f);
        Invoke("Change3", 15.0f);
        Invoke("Change4", 20.0f);
        Invoke("Change5", 25.0f);

        Invoke("ParticleOff1", 7.5f); //turns the particles back off for each stage of upward growth
        Invoke("ParticleOff2", 12.5f);
        Invoke("ParticleOff3", 17.5f);

        
       //perhaps also have a getcomponent for temperature which changes the rate of each Invoke command e.g. = time * 0.8 to slow rate.
    
    
        if (State1.activeSelf)
        {
            MushroomPoints = 0f * Temp.GetComponent<Temperature>().humidityMultiplier;
            // Debug.Log("Mushroom Points = " + MushroomPoints); //if State 1 is alive, Mushroom Points = 0.
        }
    }
    void Change1() //state 1 gets destroyed and replaced with state 2 model.
    {
        Destroy(State1);
        State2.SetActive(true);
        Particles.SetActive(true);
        if (State2.activeSelf) //is State 2 is alive.
        {
            MushroomPoints = 30f * Temp.GetComponent<Temperature>().humidityMultiplier; //Points for collection at this stage = 30.
            // Debug.Log(" Mushroom Points = " + MushroomPoints);
        }
    }
    void ParticleOff1() 
    {
        Particles.SetActive(false);
    }
    void Change2() //state 2 gets destroyed and replaced with state 3 model.
    {
        Destroy(State2);
        State3.SetActive(true);
        Particles.SetActive(true);
        if (State3.activeSelf) //if State 3 is alive.
        {
            MushroomPoints = 65f * Temp.GetComponent<Temperature>().humidityMultiplier; //Points for collection at this stage = 65.
            // Debug.Log("Mushroom Points = " + MushroomPoints);
        }
    }
        void ParticleOff2()
    {
        Particles.SetActive(false);
    }
        void Change3() //state 3 gets destroyed and replaced with state 4 model.
    {
        Destroy(State3);
        State4.SetActive(true);    
        Particles.SetActive(true);
        if (State4.activeSelf) //if State 4 is alive.
        {
            MushroomPoints = 100f * Temp.GetComponent<Temperature>().humidityMultiplier; //Points for collection at this stage = 100.
            // Debug.Log("Mushroom Points = " + MushroomPoints);
        }
    }
        void ParticleOff3()
    {
        Particles.SetActive(false);
    }
        void Change4() //state 4 gets destroyed and replaced with state 5 model.
    {
        Destroy(State4);
        State5.SetActive(true);
        if (State5.activeSelf) //if State 5 is alive.
        {
            MushroomPoints = 65f * Temp.GetComponent<Temperature>().humidityMultiplier; //Points for collection at this stage = 65.
            // Debug.Log("Mushroom Points = " + MushroomPoints);
        }
    }
        void Change5() //state 5 gets destroyed and replaced with state 6 model.
    {
        Destroy(State5);
        State6.SetActive(true);
        if (State6.activeSelf) //if State 6 is alive.
        {
            MushroomPoints = 0f * Temp.GetComponent<Temperature>().humidityMultiplier; //Points for collection at this stage = 0
            // Debug.Log("Mushroom Points = " + MushroomPoints);
        }
    }




}