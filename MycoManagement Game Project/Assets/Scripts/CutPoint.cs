using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutPoint : MonoBehaviour
{
    bool beenCut = false;

    private void OnMouseDown() 
    {
        Debug.Log("clicked");

        if(beenCut == false)
        {
            beenCut = true;
            this.transform.parent.gameObject.GetComponent<GillExtraction>().UpdateCut();
        }
    }
}
