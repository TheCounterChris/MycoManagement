using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour
{
    public float speed = 5f;//robot speed
    public float rotSpeed = 5.0f;//how fast he turns
    public Rigidbody robotRigid;//rigid body of the robot, what we are actually moving
    Vector3 movement;//to store input

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");//get east west movement
        movement.z = Input.GetAxisRaw("Vertical");//get north south movement
    }

    void FixedUpdate()
    {
        robotRigid.MovePosition(robotRigid.position + movement.normalized * speed * Time.fixedDeltaTime);//move robot the direction of the input    
        
        Quaternion qTo = Quaternion.LookRotation(movement);//turn the input into rotation data
        
        if(movement != Vector3.zero)//as long as there is input, turn the robot. This keeps the robot to turning to 0, 0, 0 when there is no input.
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, qTo, rotSpeed * Time.fixedDeltaTime);//rotate towards new direction over time as set by rotSpeed
        }
    }
}//class