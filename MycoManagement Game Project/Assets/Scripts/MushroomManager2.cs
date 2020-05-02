using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManager2 : MonoBehaviour
{

    public List<MushroomState> mushrooms = new List<MushroomState>();

    public GameObject cordySpore, cordyBud, cordyMed;

    public GameObject lionSpore, lionBud, lionMed;

    MushroomState[] mushArray;

    public GameObject IncubatorController;

    public float incubatorTemperature;
    public float incubatorHumidity;

    float idealHumidity = 90f;
    float growthModifer = 1f;
    public List<float> mushGrowth = new List<float>();
    // public List<float> potency = new List<float>();
    // public float potency = 1;
    // StateChanger stateChanger;

    public List<GameObject> substrateStage = new List<GameObject>();
    // int nextStage;

    void FixedUpdate()
    {

        incubatorTemperature = IncubatorController.GetComponentInChildren<IncubatorControls>().incubatorTemp;
        incubatorHumidity = IncubatorController.GetComponentInChildren<IncubatorControls>().incubatorHumidity;

        if (mushArray != null)
        {
            foreach (MushroomState m in mushArray)
            {
                if (m.inIncubator == true)
                {
                    //  Calculates growthModifier in relation to ideal temperature of 25 degrees
                    // and clamps the grothModifier to have max and min speed 4x and 1/4x speed respectively
                    growthModifer = Mathf.Clamp((incubatorTemperature / 25f), .25f, 4f);

                    if (incubatorTemperature > 25)
                    {
                        // If temperature exceeds 25 degrees the potency is decreased in relation to how 
                        // far past the threshold the temperature has gone 
                        m.potency -= ((incubatorTemperature - 25) / 10000f);
                    }

                    if (incubatorHumidity != 90f)
                    {
                        // If incubatorHumidity exceeds idealHumidity (default 90%) the potency is increased
                        // and if the incubatorHumidity is below idealHumidity potency is decreased. Both of 
                        // these are proportional to how far incubatorHumidity is from idealHumidity
                        m.potency *= (incubatorHumidity + ((idealHumidity - 1) * idealHumidity)) / Mathf.Pow(idealHumidity, 2);
                    }

                    m.potency = Mathf.Clamp(m.potency, 0.1f, 10f);

                    // Each mushrooms' growth is calculated by the growth modifier * the length of time the
                    // mushroom has been in the incubator. This is then added to the mushrooms list item
                    mushGrowth[mushrooms.IndexOf(m)] = m.mushGrowth + ((Time.time - m.startTime) * growthModifer);

                    // Debug.Log("Mushroom Growth: " + mushGrowth[mushrooms.IndexOf(m)]);
                    // Debug.Log("Mushroom Potency: " + m.potency);
                    // // Debug.Log("Incubator Humidity " + m.humidity);

                    // // stage = Mathf.Clamp(stage, 0, 5);
                    // // Checks if this stage is earlier then the mushroom stage
                    // Debug.Log("Mushroom Name -----------" + m.Name);
                    // Debug.Log("Mushroom Growth -----------" + mushGrowth[mushrooms.IndexOf(m)]);
                    switch ((int)mushGrowth[mushrooms.IndexOf(m)])
                    {
                        case 0:
                            m.stage = MushroomStage.spore;
                            break;
                        case 10:
                            m.stage = MushroomStage.budding;
                            if (m.Name == "Cordyceps")
                            {
                                ChangeMushModel(cordySpore, cordyBud);
                            }

                            if (m.Name == "Lionsmane")
                            {
                                ChangeMushModel(lionSpore, lionBud);
                            }
                            break;
                        case 20:
                            m.stage = MushroomStage.medium;
                            if (m.Name == "Cordyceps")
                            {
                                ChangeMushModel(cordyBud, cordyMed);
                            }
                            if (m.Name == "Lionsmane")
                            {
                                ChangeMushModel(lionBud, lionMed);
                            }                            
                            break;
                        case 30:
                            m.stage = MushroomStage.full;
                            break;
                        case 40:
                            m.stage = MushroomStage.dying;
                            break;
                        case 50:
                            m.stage = MushroomStage.dead;
                            break;

                        default:
                            break;
                    }

                    // Debug.Log(m.stage);

                }
            }
        }
    }

    public void ChangeMushModel(GameObject oldModel, GameObject newModel)
    {
        oldModel.SetActive(false);
        newModel.SetActive(true);
    }


    public void AddMushroom(string name)
    {
        // As each substrate is added to the incubator, its name, entrance time and a confirmation bool are 
        // added to the MushroomState list. The mushGrowth list also adds another item in order to allow the 
        // growths to be independently calculated. The mushroom list is then converted into an array for computation
        MushroomState m = new MushroomState();
        m.Name = name;
        m.startTime = Time.time;
        mushGrowth.Add(1);
        m.inIncubator = true;
        Debug.Log("START TIME ----" + m.startTime);
        Debug.Log("Name " + name);
        Debug.Log("Mushroom Growth " + m.mushGrowth);
        Debug.Log("In Incubator: " + m.inIncubator);

        mushrooms.Add(m);
        mushArray = mushrooms.ToArray(); // Every time you add or delete something from the list, you MUSH call this line and Remove(m)
    }

    public void StopMushroom(string name)
    {
        foreach (MushroomState m in mushrooms)
        {
            if (m.Name == name)
            {
                m.startTime = 0;
                m.mushGrowth = mushGrowth[mushrooms.IndexOf(m)];
                // m.stage = ;
                m.inIncubator = false;
                // Debug.Log(mushrooms.IndexOf(m));
                Debug.Log("Name: " + name);
                // Debug.Log("In Incubator: " + m.inIncubator);
                Debug.Log("Stage: " + m.stage);
                Debug.Log("Mushroom Growth: " + m.mushGrowth);
                Debug.Log("Potency: " + m.potency);
                // Debug.Log("Humidity -------" + m.humidity);
                // Debug.Log("POINTS ------" + m.potency * m.mushGrowth * m.humidity);
                // mushrooms.Remove(m);
                // mushArray = mushrooms.ToArray();
                break;
            }
        }
    }

    public void RemoveMushroom(string name)
    {
        // When a substrate is removed from the incubator it's corresponding growth and potency are locked.
        // Points are calculated before the MushroomStage list is converted back to an Array.
        foreach (MushroomState m in mushrooms)
        {
            if (m.Name == name)
            {
                // m.startTime = 0;
                // m.mushGrowth = mushGrowth[mushrooms.IndexOf(m)];
                // // m.stage = ;
                // m.inIncubator = false;
                // // Debug.Log(mushrooms.IndexOf(m));
                // Debug.Log("Name ---------------" + name);
                // // Debug.Log("In Incubator: " + m.inIncubator);
                // Debug.Log("Stage: " + m.stage);
                Debug.Log("Mushroom Growth ---------" + m.mushGrowth);
                Debug.Log("Potency ---------" + m.potency);
                // Debug.Log("Humidity -------" + m.humidity);
                // Debug.Log("POINTS ------" + m.potency * m.mushGrowth * m.humidity);
                mushrooms.Remove(m);
                mushArray = mushrooms.ToArray();
                break;
            }
        }
    }
}
