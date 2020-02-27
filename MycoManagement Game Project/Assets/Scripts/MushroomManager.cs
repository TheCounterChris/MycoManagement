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

                Debug.Log("Potency: " + potency);


                float mushGrowth = ((Time.time - m.startTime) * growthModifer);

                Debug.Log("Mushroom Growth: " + mushGrowth);

                // stage = Mathf.Clamp(stage, 0, 5);
                // // Checks if this stage is earlier then the mushroom stage
                // switch (stage)
                // {
                //     case 0:
                //         m.stage = MushroomStage.spore;
                //         break;
                //     case 1:
                //         m.stage = MushroomStage.budding;
                //         break;
                //     case 2:
                //         m.stage = MushroomStage.medium;
                //         break;
                //     case 3:
                //         m.stage = MushroomStage.full;
                //         break;
                //     case 4:
                //         m.stage = MushroomStage.dying;
                //         break;
                //     case 5:
                //         m.stage = MushroomStage.dead;
                //         break;

                //     default:
                //         break;
                // }

                // Debug.Log(stage);

            }
        }

    }

    public void AddMushroom(string name)
    {
        MushroomState myMushroom = new MushroomState();
        myMushroom.startTime = Time.time;
        myMushroom.Name = name;
        myMushroom.growthRate = 100f;
        Debug.Log("Mushroom Registered");
        mushrooms.Add(myMushroom);
        mushArray = mushrooms.ToArray(); // Every time you add or delete something from the list, you MUSH call this line and Remove(myMushroom)
    }

}
