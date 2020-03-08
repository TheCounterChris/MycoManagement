using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWobble: MonoBehaviour

{
    bool still;

    bool stillSwitch;
    Vector3 originalRotation;

    float wobbleRange;

    public float wobbleDeviation;

    float wobbleTime;

    float timer;

    void Start()
    {
        originalRotation= transform.localRotation.eulerAngles;
        stillSwitch = true;
    }

    void Update()
    {

        still = GetComponentInParent<CharController>().stationary;
        if (still && stillSwitch)
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
        wobbleTime = Random.Range(1, 4);
        wobbleRange = Random.Range(wobbleDeviation, -wobbleDeviation);
        timer = Time.time + wobbleTime;
        Vector3 wobbleVector = originalRotation+ new Vector3(wobbleRange, 0, 0);
        transform.localRotation = Quaternion.Euler(wobbleVector);
        // Debug.Log("New Rotation" + wobbleVector);
        // Debug.Log("timer " + timer);
    }

}
