using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    public bool isPromptActive;
    public bool isControlPanelActive;
    public GameObject ControlPanelPrompt;
    public GameObject ControlPanelUI;
   // public Slider TempSlider;
  //  public Slider HumiditySlider;
   
    // Start is called before the first frame update
    public void Start()
    {
       // TempSlider.value = PlayerPrefs.GetFloat("");
        //HumiditySlider.value = PlayerPrefs.GetFloat("");

        ControlPanelUI.SetActive(false);
        ControlPanelPrompt.SetActive(false);
        isPromptActive = false;
        isControlPanelActive = false;

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ControlPanelPrompt.SetActive(true);
            isPromptActive = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ControlPanelPrompt.SetActive(false);
            isPromptActive = false;
        }
    }
  //  public void SetTempLevel (float sliderValue)
  //  {

  //  }
   // public void SetHumidityLevel(float sliderValue)
   // {

   // }
    // Update is called once per frame
   public void Update()
    {
        if (isPromptActive == true)
        {
            if(Input.GetKeyDown("e"))
            {
                ControlPanelPrompt.SetActive(false);
                ControlPanelUI.SetActive(true);
            }
            if(Input.GetKeyUp("e"))
            {
                ControlPanelUI.SetActive(false);
                ControlPanelPrompt.SetActive(true);
            }
        }
    }
}