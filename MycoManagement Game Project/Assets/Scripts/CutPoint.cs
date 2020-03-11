using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT GOES ON THE POINTS ON THE MUSHROOM THAT GET CUT TO RELEASE THE GILLS
public class CutPoint : MonoBehaviour
{
    bool beenCut = false;//Has this point been dragged over
    Renderer mr;//mesh renderer
    private void Start() 
    {
        mr = GetComponent<MeshRenderer>();//get mesh renderer
        mr.material.color = Color.red;//set color to red
    }

    private void OnMouseOver()//if the mouse goes over the point
    {
        Debug.Log("Mouse over");//print
        if(Input.GetMouseButton(0))//if the right mouse button is being held
        {
            Debug.Log("Button held");//print
            if(beenCut == false)//if it has not previously been cut
            {
                Debug.Log("Cut");//print
                beenCut = true;//set cut to true
                this.transform.parent.gameObject.GetComponent<GillExtraction>().UpdateCut();//cut the point

                mr.material.color = Color.blue;//change color to blue, indicating it has been cut
            }
        }        
    }
}
