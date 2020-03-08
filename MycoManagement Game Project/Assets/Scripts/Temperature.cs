using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic.IEnumerable<int>;

public class Temperature : MonoBehaviour
{
    [Range(0f, 35f)]
    public int Temp;

    [Range(0f, 100f)]
    public int Humidity;

    public float ROG; //Rate of Growth. This will be multiplied by the time taken to invoke growth state changes in order to speed up/slow down growth rates.
    // Start is called before the first frame update

    public float humidityMultiplier;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { //these temperatures affect the rate of growth for each mushroom. This could be copied and changed to create x different ROGs for different species of fungi in the game.
        if (Temp <= 10)
        {
            ROG = 0.25f;
            // Debug.Log("ROG=0.25f");
        }
        if (Temp >= 10 && Temp <= 15)
        {
            ROG = 0.5f;
            // Debug.Log("ROG=0.5f");
        }
        if (Temp >= 15 && Temp <= 20)
        {
            ROG = 0.75f;
            // Debug.Log("ROG=0.75f");
        }
        if (Temp >= 20 && Temp <= 23)
        {
            ROG = 0.9f;
            // Debug.Log("ROG=0.9f");
        }
        if (Temp >= 24 && Temp <= 25)
        {
            ROG = 1.0f;
            // Debug.Log("ROG=1.0f");
        }
        if (Temp >= 26 && Temp <= 30)
        {
            ROG = 1.75f;
            // Debug.Log("ROG=1.75f");
        }
        if (Temp >= 30 && Temp <= 35)
        {
            ROG = 2.5f;
            // Debug.Log("ROG=2.5f");
        }
        //humidity affects the score multiplier that players will receive from the harvested mushrooms.
        if (Humidity <= 10)
        {
            humidityMultiplier = 0.3f;
            // Debug.Log("Humidity Multiplier = 0.3");
        }
        if (Humidity >= 10 && Humidity <= 25)
        {
            humidityMultiplier = 0.4f;
            // Debug.Log("Humidity Multiplier = 0.4");
        }
        if (Humidity >= 25 && Humidity <= 50)
        {
            humidityMultiplier = 0.6f;
            // Debug.Log("Humidity Multiplier = 0.6");
        }
        if (Humidity >= 50 && Humidity <= 60)
        {
            humidityMultiplier = 0.7f;
            // Debug.Log("Humidity Multiplier = 0.7");
        }
        if (Humidity >= 60 && Humidity <= 70)
        {
            humidityMultiplier = 0.8f;
            // Debug.Log("Humidity Multiplier = 0.8");
        }
        if (Humidity >= 70 && Humidity <= 80)
        {
            humidityMultiplier = 0.75f;
            // Debug.Log("Humidity Multiplier = 0.75");
        }
        if (Humidity >= 80 && Humidity <= 90)
        {
            humidityMultiplier = 0.9f;
            // Debug.Log("Humidity Multiplier = 0.9");
        }
        if (Humidity >= 90 && Humidity <= 95)
        {
            humidityMultiplier = 0.95f;
            // Debug.Log("Humidity Multiplier = 0.95");
        }
        if (Humidity >= 95 && Humidity <= 99)
        {
            humidityMultiplier = 1.0f;
            // Debug.Log("Humidity Multiplier = 0.99");
        }
        if (Humidity == 100)
        {
            humidityMultiplier = 1.1f;
            // Debug.Log("Humidity Multiplier = 1.1"); //bonus 1.1x multiplier if you harvest at 100 humidity.
        }
    }

}
