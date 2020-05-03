using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour
{
    float currentSpeed;
    public float normalSpeed = 5f;//robot speed
    public float rotSpeed = 5.0f;//how fast he turns
    public float sprintMultiplier = 2f;
    float fastSpeed;

    bool isGrounded;

    public bool isMoving;

    public LibPdInstance pdPatch;

    public Rigidbody robotRigid;//rigid body of the robot, what we are actually moving
    Vector3 movement;//to store input

    public Animator animator;
    float animFastSpeed;
    public float animNormalSpeed = 1;

    // public LibPdInstance pdPatch;

    void Start()
    {
        fastSpeed = sprintMultiplier * normalSpeed;
        animFastSpeed = sprintMultiplier * animNormalSpeed;
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");//get east west movement
        movement.z = Input.GetAxisRaw("Vertical");//get north south movement

        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : normalSpeed;

        if (movement != Vector3.zero)
        {
            animator.SetBool("Moving", true);
            animator.speed = Input.GetKey(KeyCode.LeftShift) ? animFastSpeed : animNormalSpeed;
            pdPatch.SendFloat("velocity", Mathf.Clamp(currentSpeed / 30, 0, 1));
            isMoving = true;
            if(isGrounded)
            {
                pdPatch.SendFloat("grounded", 1);
            }
            if (!isGrounded)
            {
                pdPatch.SendFloat("grounded", 0);
            }
        }
        else
        {
            animator.SetBool("Moving", false);
            pdPatch.SendFloat("velocity", 0);

            isMoving = false;
        }
    }

    void FixedUpdate()
    {
        robotRigid.MovePosition(robotRigid.position + movement.normalized * currentSpeed * Time.fixedDeltaTime);//move robot the direction of the input    

        //Debug.Log(movement.normalized * currentSpeed * Time.fixedDeltaTime);

        if (movement != Vector3.zero)//as long as there is input, turn the robot. This keeps the robot to turning to 0, 0, 0 when there is no input.
        {
            Quaternion qTo = Quaternion.LookRotation(movement);//turn the input into rotation data
            transform.rotation = Quaternion.Slerp(transform.rotation, qTo, rotSpeed * Time.fixedDeltaTime);//rotate towards new direction over time as set by rotSpeed
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            robotRigid.AddForce(up * 5, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Camera"))
        {
            pdPatch.SendBang("cam");
            Debug.Log("camera");
        }
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
}//class