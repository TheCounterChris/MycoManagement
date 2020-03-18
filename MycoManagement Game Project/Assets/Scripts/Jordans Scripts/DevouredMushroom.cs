using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevouredMushroom : MonoBehaviour
{
   
    public float startTime = 5.0f;
    float countDownLimit;
    public bool isEating = false;


    


    // Start is called before the first frame update
    void Start()
    {
       //   for(int i = 0; i <5; i++)
        //{
        //    Debug.Log("this is script B");
      //  }

        Debug.Log("Looking for some scran");
        countDownLimit = 0;



     
 }

    public void Update()
    {
        if (isEating == true)
        {
            EatMushroom();
        }

        if (startTime <= 0)
        {
            
            startTime = countDownLimit;
        }

        if (startTime == countDownLimit)
        {
            isEating = false;
            DestroyMushroom();
        }  


    }
    public void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.tag == "Mushroom")
        // {


        //     isEating = true;
        // }

        StartCoroutine("DestroyShroom");
    }
    public void EatMushroom()
    {

        startTime -= Time.deltaTime;
        Debug.Log("is eating the mushroom");

    }
    public void DestroyMushroom()
    {
        Debug.Log("please work");
        Destroy(gameObject);
    }

    IEnumerator DestroyShroom() {
        Debug.Log("destroying");
        yield return new WaitForSeconds(5f);
        Debug.Log("destroyed");
    }
}



