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
        InvokeRepeating("Decrease", 2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        incubatorTemp = incubatorTempSlider.value;
        incubatorHumidity = incubatorHumiditySlider.value;
        tempText.text = incubatorTemp.ToString("F1") + "°";
        humText.text = incubatorHumidity.ToString("0") + "%";
    }

    void Decrease()
    {
        temp = Mathf.Clamp(((float)Random.Range(1, 100) / 100), 0f, 1f);
        humid = Mathf.Clamp(((float)Random.Range(1, 100) / 100), 0f, 1f);
        incubatorTempSlider.value -= temp;
        incubatorHumiditySlider.value -= humid;
        Debug.Log("TEMP " + temp);
        Debug.Log("HUMID " + humid);
        // incubatorTempSlider.value -= 0.1f*(1+Mathf.Sin(Mathf.Repeat((Time.time), 6)));
    }
}
