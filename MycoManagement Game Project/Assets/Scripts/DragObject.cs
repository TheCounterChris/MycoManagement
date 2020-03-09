﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;//how far the mouse moves

    private float mZCoord;//how deep the object the mouse clicks on is

    private void OnMouseDown() 
    {
        mZCoord = Camera.current.WorldToScreenPoint(gameObject.transform.position).z;//find depth of object from camera
        Debug.Log("mouse Z coordinate/ object depth: " + mZCoord);

        mOffset = gameObject.transform.position - GetMouseWorldPos();//update how far the mouse is moving

        gameObject.GetComponent<Rigidbody>().useGravity = false;//turn off gravity
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;//turn on kinematic
    }

    private Vector3 GetMouseWorldPos()//figure out mouse delta
    {
        Vector3 mousePoint = Input.mousePosition;//store mouse position

        mousePoint.z = mZCoord;//depth of mouse

        return mousePoint;//send it
    }

    private void OnMouseDrag() {
        gameObject.transform.position = GetMouseWorldPos() + mOffset;//move the object
    }

    private void OnMouseUp() 
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;//turn on gravity
        gameObject.GetComponent<Rigidbody>().isKinematic = false;//turn off kinematic
    }
}
