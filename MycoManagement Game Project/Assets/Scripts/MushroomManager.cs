// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MushroomManager : MonoBehaviour
// {

//     public List<MushroomState> mushrooms = new List<MushroomState>();

//     MushroomState[] mushArray;

//     public float incubatorTemperature = 25f;
//     float growthModifer = 1f;
//     float thresh = 1.05f;
//     // public float potency = 1;

//     public List<float> mushGrowth = new List<float>();

//     public List<float> mushPotency = new List<float>();

//     public List<int> mushStage = new List<int>();
//     public int stage;
//     int nextStage;

//     void Update()
//     {

//         if (mushArray != null)
//         {
//             foreach (MushroomState m in mushArray)
//             {
//                 if (m.inIncubator == true)
//                 {
//                     growthModifer = Mathf.Clamp((incubatorTemperature / 25f), .25f, 4f);

//                     if (growthModifer > thresh)
//                     {
//                         // if (m.potency < 0.1)
//                         //     potency = 1;
//                         // potency -= 0.0001f;
//                         mushPotency[mushrooms.IndexOf(m)] -= 0.0001f;
//                     }


//                     // mushGrowth = m.mushGrowth + ((Time.time - m.startTime) * growthModifer);
//                     mushGrowth[mushrooms.IndexOf(m)] =  m.mushGrowth + ((Time.time - m.startTime) * growthModifer);

//                     // Debug.Log("Mushroom Growth: " + mushGrowth[mushrooms.IndexOf(m)]);
//                     Debug.Log("Mushroom Potency: " + mushPotency[mushrooms.IndexOf(m)]);
                    
//                     // Debug.Log("Potency: " + potency);


//                     // Sets thresholds for growth stages
//                     mushStage[mushrooms.IndexOf(m)] = StageThresh(mushGrowth[mushrooms.IndexOf(m)], 10f, 25f, 50f, 75f, 100f);
//                     // stage = Mathf.Clamp(stage, 0, 5);
//                     // Checks if this stage is earlier then the mushroom stage
                    
//                     switch (mushStage[mushrooms.IndexOf(m)])
//                     {
//                         case 0:
//                             m.stage = MushroomStage.spore;
//                             break;
//                         case 1:
//                             m.stage = MushroomStage.budding;
//                             break;
//                         case 2:
//                             m.stage = MushroomStage.medium;
//                             break;
//                         case 3:
//                             m.stage = MushroomStage.full;
//                             break;
//                         case 4:
//                             m.stage = MushroomStage.dying;
//                             break;
//                         case 5:
//                             m.stage = MushroomStage.dead;
//                             break;

//                         default:
//                             break;
//                     }
//                 }
//             }
//         }

//     }


//     public void AddMushroom(string name)
//     {
//         MushroomState m = new MushroomState();

//         m.startTime = Time.time;
//         m.Name = name;
//         mushGrowth.Add(1);
//         mushPotency.Add(1);
//         mushStage.Add(1);
//         // m.potency = potency;
//         m.inIncubator = true;

//         Debug.Log("START TIME ----" + m.startTime);
//         // Debug.Log("Name " + name);
//         Debug.Log("Mushroom Growth " + m.mushGrowth);
//         // Debug.Log("POTENCY ------" + m.potency);
//         // Debug.Log("In Incubator: " + m.inIncubator);

//         mushrooms.Add(m);
//         mushArray = mushrooms.ToArray(); // Every time you add or delete something from the list, you MUSH call this line and Remove(m)
//     }

//     public void RemoveMushroom(string name)
//     {
//         foreach (MushroomState m in mushrooms)
//         {
//             if (m.Name == name)
//             {
//                 m.startTime = 0;
//                 m.mushGrowth = mushGrowth[mushrooms.IndexOf(m)];
//                 m.potency = mushPotency[mushrooms.IndexOf(m)];
//                 // m.stage = mushStage[mushrooms.IndexOf(m)];
//                 // m.potency = potency;
//                 m.inIncubator = false;
//                 // Debug.Log(mushrooms.IndexOf(m));
//                 Debug.Log("Name ---------------" + name);
//                 // Debug.Log("In Incubator: " + m.inIncubator);
//                 Debug.Log("Stage: " + m.stage);
//                 Debug.Log("POTENCY ---------------" + m.potency);
//                 Debug.Log("Mushroom Growth ---------" + m.mushGrowth);
//                 // Debug.Log("Points: " + m.potency * m.mushGrowth);
//                 mushrooms.Remove(m);
//                 // mushrooms.RemoveAt(m);
//                 mushArray = mushrooms.ToArray();
//                 break;
//             }
//         }
//     }


//     public int StageThresh(float mushGrowth, float a, float b, float c, float d, float e)
//     {
//         // int stage;
//         // int nextStage;

//         if (mushGrowth >= e)
//         {
//             stage = 5;
//         }
//         if (mushGrowth <= e && mushGrowth >= d)
//         {
//             stage = 4;
//         }
//         if (mushGrowth <= d && mushGrowth >= c)
//         {
//             stage = 3;
//         }
//         if (mushGrowth <= c && mushGrowth >= b)
//         {
//             stage = 2;
//         }
//         if (mushGrowth <= b && mushGrowth >= a)
//         {
//             stage = 1;
//         }
//         if (mushGrowth <= a && mushGrowth >= 0f)
//         {
//             stage = 0;
//         }

//         if (stage < nextStage - 1)
//         {
//             stage = nextStage - 1;
//         }

//         nextStage = stage + 1;

//         return stage;

//         Debug.Log("Stage "+ stage);
//         Debug.Log("Next Stage " + nextStage);
//     }

// }
