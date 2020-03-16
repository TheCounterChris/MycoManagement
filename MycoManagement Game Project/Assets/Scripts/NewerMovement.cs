using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewerMovement : MonoBehaviour
{
    // public LibPdInstance pdPatch;
    public float normalSpeed = 5f;//robot speed

    float fastSpeed;

    float speed;

    bool isGrounded;

    public bool isMoving;
    public float rotSpeed = 5.0f;//how fast he turns
    public Rigidbody robotRigid;//rigid body of the robot, what we are actually moving
    Vector3 movement;//to store input

    // public Animator animator;

    public LibPdInstance pdPatch;

    float velocity;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");//get east west movement
        movement.z = Input.GetAxisRaw("Vertical");//get north south movement
        fastSpeed = 1.4f * normalSpeed;

        // if (movement != Vector3.zero)
        // {
        //     animator.SetBool("Moving", true);
        // }
        // else
        // {
        //     animator.SetBool("Moving", false);
        // }
    }

    void FixedUpdate()
    {
        // if (Input.GetKey(KeyCode.LeftShift))
        // {
        //     speed = fastSpeed;
        // }

        speed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : normalSpeed;

        robotRigid.MovePosition(robotRigid.position + movement.normalized * speed * Time.fixedDeltaTime);//move robot the direction of the input    

        // Debug.Log(movement.normalized * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            robotRigid.AddForce (up * 5, ForceMode.Impulse);
        }


        if (movement != Vector3.zero)//as long as there is input, turn the robot. This keeps the robot to turning to 0, 0, 0 when there is no input.
        {
            Quaternion qTo = Quaternion.LookRotation(movement);//turn the input into rotation data
            transform.rotation = Quaternion.Slerp(transform.rotation, qTo, rotSpeed * Time.fixedDeltaTime);//rotate towards new direction over time as set by rotSpeed
            velocity = Mathf.Clamp(Mathf.Max(Mathf.Abs(movement.x), Mathf.Abs(movement.z)), 0f, 0.7f);
            pdPatch.SendFloat("velocity", Mathf.Clamp(speed / 15, 0, 1));
            isMoving = true;

        }

        else
        {
            pdPatch.SendFloat("velocity", 0);
            isMoving = false;
        }

        // Debug.Log(isMoving);
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.name == "Mesh Collider")
        {
            isGrounded = true;
        }    
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Mesh Collider")
        {
            isGrounded = false;
        }
    }
}