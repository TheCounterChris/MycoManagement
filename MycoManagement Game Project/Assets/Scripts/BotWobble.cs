using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWobble: MonoBehaviour

{
    bool moving;

    bool stillSwitch;
    Vector3 originalRotation;

    float wobbleRange;

    public float wobbleDeviation;
    // public Vector3 wobbleVector;

    float wobbleTime;

    float timer;

    void Start()
    {
        originalRotation = transform.localRotation.eulerAngles;
    //    GameObject Armature = GameObject.Find("Armature");
    //    originalRotation = Armature.transform.localRotation.eulerAngles;
        Debug.Log(originalRotation);
        stillSwitch = true;
    }

    void Update()
    {
        // still = GetComponentInParent<CharController>().stationary; // FUN - G
        moving = GetComponentInParent<NewerMovement>().isMoving; // AdamRobot
        if (moving == false && stillSwitch == true)
        {
            if (stillSwitch)
            {
                Wobbler();
                stillSwitch = !stillSwitch;
            }
        }

        if (Time.time > timer)
        {
            stillSwitch = true;
        }

    }

    void Wobbler()
    {
        wobbleTime = Random.Range(1, 5);
        wobbleRange = Random.Range(wobbleDeviation, -wobbleDeviation);
        timer = Time.time + wobbleTime;
        Vector3 wobbleVector = originalRotation + new Vector3(wobbleRange, 0, 0);
        transform.localRotation = Quaternion.Euler(wobbleVector);
        // Debug.Log("New Rotation" + wobbleVector);
        // Debug.Log("timer " + timer);
    }

}
