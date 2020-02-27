using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform PlayerTransform;

    public Vector3 _cameraOffset;
    public bool LookAtPlayer = false; //camera moves around the player.
    public bool RotateAroundPlayer = false; //switches on rotation around the Y Axis around the player using the X Axis of the mouse.
    public float RotSpeed = 10f; //speed of rotation around player
   

[Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f; //smoothly follow the player, used with slerp later on in script.

    // Start is called before the first frame update
    void Start()
    {
       _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate(){
    if(RotateAroundPlayer)
    {
        Quaternion camTurnAngle = 
        Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotSpeed, Vector3.up);

        _cameraOffset = camTurnAngle * _cameraOffset;
    }
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(PlayerTransform.position, newPos, SmoothFactor);
        if(LookAtPlayer || RotateAroundPlayer)
        transform.LookAt(PlayerTransform);
        
    }}

    
}
