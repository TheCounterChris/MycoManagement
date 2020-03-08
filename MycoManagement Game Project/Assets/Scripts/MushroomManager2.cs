using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManager2 : MonoBehaviour
{

    public List<MushroomState> mushrooms = new List<MushroomState>();

    MushroomState[] mushArray;

    public float incubatorTemperature = 25f;
    public float incubatorHumidity = 90f;
    float growthModifer = 1f;
    public List<float> mushGrowth = new List<float>();
    // public List<float> potency = new List<float>();
    // public float potency = 1;
    public int stage;
    int nextStage;

    void FixedUpdate()
    {

        if (mushArray != null)
        {
            foreach (MushroomState m in mushArray)
            {
                if (m.inIncubator == true)
                {
                    growthModifer = Mathf.Clamp((incubatorTemperature / 25f), .25f, 4f);

                    if (incubatorTemperature > 25)
                    {
                        m.potency -= ((incubatorTemperature - 25)/10000f);
                    }

                    if (incubatorHumidity != 90f)
                    {
                        m.potency *= (incubatorHumidity + (89*90))/8100;
                    }

                    mushGrowth[mushrooms.IndexOf(m)] =  m.mushGrowth + ((Time.time - m.startTime) * growthModifer);

                    Debug.Log("Mushroom Growth: " + mushGrowth[mushrooms.IndexOf(m)]);
                    Debug.Log("Mushroom Potency: " + m.potency);
                    // Debug.Log("Incubator Humidity " + m.humidity);
                    
                    // stage = Mathf.Clamp(stage, 0, 5);
                    // Checks if this stage is earlier then the mushroom stage
                    // Debug.Log("Mushroom Name -----------" + m.Name);
                    // Debug.Log("Mushroom Growth -----------" + mushGrowth[mushrooms.IndexOf(m)]);
                    switch ((int) mushGrowth[mushrooms.IndexOf(m)])
                    {
                        case 0:
                            m.stage = MushroomStage.spore;
                            break;
                        case 10:
                            m.stage = MushroomStage.budding;
                            break;
                        case 20:
                            m.stage = MushroomStage.medium;
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
                }
            }
        }

    }

    public void AddMushroom(string name)
    {
        MushroomState m = new MushroomState();
        m.Name = name;
        m.startTime = Time.time;
        mushGrowth.Add(1);
        m.inIncubator = true;

        Debug.Log("START TIME ----" + m.startTime);
        // Debug.Log("Name " + name);
        Debug.Log("Mushroom Growth " + m.mushGrowth);
        // Debug.Log("In Incubator: " + m.inIncubator);

        mushrooms.Add(m);
        mushArray = mushrooms.ToArray(); // Every time you add or delete something from the list, you MUSH call this line and Remove(m)
    }

    public void RemoveMushroom(string name)
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
                Debug.Log("Name ---------------" + name);
                // Debug.Log("In Incubator: " + m.inIncubator);
                Debug.Log("Stage: " + m.stage);
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
