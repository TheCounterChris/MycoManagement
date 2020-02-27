using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    public LibPdInstance pdPatch;
    [SerializeField]
    float moveSpeed = 4f;
    Vector3 forward, right;

    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
            pdPatch.SendFloat("velocity", Mathf.Clamp(velocity, 0, 1));
        }
        else
        {
             pdPatch.SendFloat("velocity", 0);
        }
    }
    void Move()
    {
        // Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        // Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        // Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        Debug.Log("HEADING" + heading);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
        velocity = moveSpeed * Mathf.Clamp(Mathf.Max(Mathf.Abs(heading.x), Mathf.Abs(heading.z)), 0f, 0.7f);

        Debug.Log("velocity" + velocity);
        // pdPatch.SendFloat("velocity", Mathf.Clamp(velocity, 0, 1));
    }
}

