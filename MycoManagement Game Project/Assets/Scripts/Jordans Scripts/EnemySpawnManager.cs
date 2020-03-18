using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] pests;
    public Vector3 spawnLocation;
    public float spawnWaitTime =5f;
    public float shortestSpawnWaitTime=1f;
    public float longestSpawnWaitTime=20f;
    public int startTime;
    public bool isStopped;
    public GameObject Mushroom;

    public int PestsSpawned;
    public int MaxPests;


    int randomPest;
    // Start is called before the first frame update
    public void Start()
    {
      Mushroom = GameObject.FindGameObjectWithTag("Mushroom");
    }
    public void OnTriggerEnter(Collider col)
    {
        if (GameObject.FindWithTag("Mushroom"))
        {
            StartCoroutine(waitSpawner());
            Debug.Log("istriggered");
        }
        else
        {
            Debug.Log("do nothing");
        }
    }
 

    // Update is called once per frame
    public void Update()
    {
       if(MaxPests<=PestsSpawned)
        {
            isStopped = true;
        }
        else
        {
            isStopped = false;
        }

        spawnWaitTime = Random.Range(shortestSpawnWaitTime, longestSpawnWaitTime);

       
    }
    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startTime);

        while (!isStopped)
        {
            randomPest = Random.Range(0, 2);
            Vector3 spawnLocations = new Vector3(Random.Range(-spawnLocation.x, spawnLocation.x),1, Random.Range(-spawnLocation.z, spawnLocation.z));
            Instantiate(pests[randomPest], spawnLocation + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWaitTime);
            Debug.Log("isspawning");
        }
        
    }
}
