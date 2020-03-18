using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempAndHumidityVariableTest : MonoBehaviour
{
    public float Temperature;
    public float Humidity;

    public Slider tempSlider;
    public Slider humiditySlider;

    public void Start()
    {

    }
    public void Update()
    {
        tempSlider.value = Temperature;
        humiditySlider.value = Humidity;

        TempTimer();
        HumidityTimer();
       

    }
    public void TempTimer()
    {
        Temperature = Mathf.Clamp(Temperature, 0f, 100f) - Time.deltaTime;
    }
    public void HumidityTimer()
    {
        Humidity = Mathf.Clamp(Humidity, 0f, 100f) - Time.deltaTime;
    }

    public void AdjustTemperature(float newTemperature)
    {
        Debug.Log("temp is changing");
        Temperature = newTemperature;
        tempSlider.value = newTemperature; 
        
    }
     public void AdjustHumidity(float newHumidity)
    {
        Debug.Log("AHumidity is changing");
        Humidity = newHumidity;
        humiditySlider.value = newHumidity;    
    }
}
