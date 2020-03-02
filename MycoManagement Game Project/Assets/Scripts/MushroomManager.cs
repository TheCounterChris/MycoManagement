using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManager : MonoBehaviour
{

    public List<MushroomState> mushrooms = new List<MushroomState>();

    MushroomState[] mushArray;

    public float incubatorTemperature = 25f;
    public float growthModifer = 1f;
    float thresh = 1.05f;
    public float potency = 1f;

    float mushGrowth;

    public int stage;

    int nextStage;

    // Update is called once per frame
    void Update()
    {
        if (mushArray != null)
        {
            foreach (MushroomState m in mushArray)
            {
                growthModifer = Mathf.Clamp((incubatorTemperature / 25f), .25f, 4f);


                if (growthModifer > thresh)
                {
                    potency -= 0.0001f;
                }

                mushGrowth = ((Time.time - m.startTime) * growthModifer);


                // Sets thresholds for growth stages
                StageThresh(mushGrowth, 10f, 25f, 50f, 75f, 100f);


                // Debug.Log("Mushroom Growth: " + mushGrowth);
                // Debug.Log("Potency: " + potency);

                // stage = Mathf.Clamp(stage, 0, 5);
                // Checks if this stage is earlier then the mushroom stage
                switch (stage)
                {
                    case 0:
                        m.stage = MushroomStage.spore;
                        break;
                    case 1:
                        m.stage = MushroomStage.budding;
                        break;
                    case 2:
                        m.stage = MushroomStage.medium;
                        break;
                    case 3:
                        m.stage = MushroomStage.full;
                        break;
                    case 4:
                        m.stage = MushroomStage.dying;
                        break;
                    case 5:
                        m.stage = MushroomStage.dead;
                        break;

                    default:
                        break;
                }
            }
        }

    }

    public void StageThresh(float mushGrowth, float a, float b, float c, float d, float e)
    {
        if (mushGrowth >= e)
        {
            stage = 5;
        }
        if (mushGrowth <= e && mushGrowth >= d)
        {
            stage = 4;
        }
        if (mushGrowth <= d && mushGrowth >= c)
        {
            stage = 3;
        }
        if (mushGrowth <= c && mushGrowth >= b)
        {
            stage = 2;
        }
        if (mushGrowth <= b && mushGrowth >= a)
        {
            stage = 1;
        }
        if (mushGrowth <= a && mushGrowth >= 0f)
        {
            stage = 0;
        }

        if (stage < nextStage - 1)
        {
            stage = nextStage - 1;
        }

        nextStage = stage + 1;

        // Debug.Log("Stage "+ stage);
        // Debug.Log("Next Stage " + nextStage);
    }

    public void AddMushroom(string name)
    {
        MushroomState myMushroom = new MushroomState();
        myMushroom.startTime = Time.time;
        myMushroom.Name = name;
        myMushroom.growthRate = 100f;
        Debug.Log("Mushroom Registered");
        Debug.Log("Name" + name);
        mushrooms.Add(myMushroom);
        mushArray = mushrooms.ToArray(); // Every time you add or delete something from the list, you MUSH call this line and Remove(myMushroom)
    }

    public void RemoveMushroom(string name)
    {
        foreach (MushroomState m in mushrooms)
        {
            if (m.Name == name)
            {
                mushrooms.Remove(m);
                break;
            }
        }
    }

}
