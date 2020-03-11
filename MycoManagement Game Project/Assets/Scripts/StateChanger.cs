using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    MushroomStage mushroomStage;

    public List<GameObject> SubstrateState = new List<GameObject>();
    public GameObject State1; //simple game objects that depict each stage of growth through a different model. These will be detroyed throughout the growth process.
    public GameObject State2;
    public GameObject State3;
    public GameObject State4;
    public GameObject State5;
    public GameObject State6;
    // public GameObject Particles; //particle effect to show visual signal of when positive growth happens
    void Start()
    {
        SubstrateState.Add(State1);
        SubstrateState.Add(State2);
        SubstrateState.Add(State3);
        // SubstrateState.Add(State4);
        // SubstrateState.Add(State5);
        // SubstrateState.Add(State6);
        State1.SetActive(true);

        for(int s = 1; s < SubstrateState.Count; s ++)
        {
            SubstrateState[s].SetActive(false);
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     foreach (MushroomStage m in mushroomStage)
    //     {
            
    //     }
    // }
    
    public void ChangeState(int targetState)
    {
        Destroy(SubstrateState[targetState-1]);
        SubstrateState[targetState].SetActive(true);
    }
}
