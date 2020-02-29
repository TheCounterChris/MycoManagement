using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS ATTACHED TO THE MUSHROOM
public class RotateObject : MonoBehaviour
{
    public float sensitivity = 300f;//How fast the object rotates
    Vector3 mouseReference;//Where mouse is //I guess i don't need these but i don't want to remove it yet
    Vector3 mouseOffset;//how far the mouse travels //I guess i don't need these but i don't want to remove it yet
    Vector3 rotation = Vector3.zero;//rotation of the object //I guess i don't need these but i don't want to remove it yet
    bool isRotating;//if object is rotating
    
    void Update()
    {
        if (isRotating)//if object is being rotated
          {        
            transform.Rotate((Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime), -(Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime), 0, Space.World);//rotate object
          }
        
    }

    private void OnMouseDown()//when mouse is clicked
    {
        isRotating = true;
    }

    private void OnMouseUp()//when mouse is unclicked
    {
        isRotating = false;
    }
}//class
