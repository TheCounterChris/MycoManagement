using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutPoint : MonoBehaviour
{
    bool beenCut = false;

    Renderer mr;

    // private void OnMouseDown() 
    // {
    //     Debug.Log("clicked");

    //     if(beenCut == false)
    //     {
    //         beenCut = true;
    //         this.transform.parent.gameObject.GetComponent<GillExtraction>().UpdateCut();
    //     }
    // }

    private void Start() 
    {
        mr = GetComponent<MeshRenderer>();
        mr.material.color = Color.red;
    }

    private void OnMouseOver()
    {
        Debug.Log("MOUSE OVER");
        if(Input.GetMouseButton(0))
        {
            Debug.Log("BURRON HELD");
            if(beenCut == false)
            {
                Debug.Log("CUT");
                beenCut = true;
                this.transform.parent.gameObject.GetComponent<GillExtraction>().UpdateCut();

                mr.material.color = Color.blue;
            }
        }        
    }
}
