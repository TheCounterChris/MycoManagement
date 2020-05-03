using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncubatorControls : MonoBehaviour
{

    public Slider incubatorTempSlider;

    public Slider incubatorHumiditySlider;

    public float incubatorTemp;

    public float incubatorHumidity;

    float temp;

    float humid;

    public Text tempText;
    public Text humText;

    void Start()
    {
        incubatorTemp = incubatorTempSlider.value;
        incubatorHumidity = incubatorHumiditySlider.value;
        InvokeRepeating("Decrease", 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        incubatorTemp = incubatorTempSlider.value;
        incubatorHumidity = incubatorHumiditySlider.value;
        Debug.Log(incubatorTempSlider.value);
        tempText.text = incubatorTemp.ToString("F1") + "°";
        humText.text = incubatorHumidity.ToString("0") + "%";
    }

    void Decrease()
    {
        temp = (float)Random.RandomRange(1, 100)/100;
        humid = (float)Random.RandomRange(1, 100)/100;
        incubatorTempSlider.value -= temp;
        incubatorHumiditySlider.value -= humid;
        // incubatorTempSlider.value -= 0.1f*(1+Mathf.Sin(Mathf.Repeat((Time.time), 6)));
    }
}
