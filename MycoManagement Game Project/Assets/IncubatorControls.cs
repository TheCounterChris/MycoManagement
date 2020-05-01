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
    void Start()
    {
        incubatorTemp = incubatorTempSlider.value;
        incubatorHumidity = incubatorHumiditySlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        incubatorTemp = incubatorTempSlider.value;
        incubatorHumidity = incubatorHumiditySlider.value;
    }
}
