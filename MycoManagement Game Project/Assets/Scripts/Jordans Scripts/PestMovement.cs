using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PestMovement : MonoBehaviour
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;
   public bool reachedFinalDestination;


    // Start is called before the first frame update
    void Start()
    {
        

      
        enabled = true;
        reachedFinalDestination = false;

        _navMeshAgent = this.GetComponent<NavMeshAgent>();
     
      

    }
    public void Update()
    {
        if( reachedFinalDestination == true)
        { 
            Debug.Log("get wrecked");
           this.GetComponent<NavMeshAgent>().enabled = false;
        }  
        
        //if (_navMeshAgent == null)
       // {
           
       // }
        else
        {
            SetDestination();

        }
    }
   


    public void SetDestination()
    {
        Vector3 targetVector = _destination.transform.position;
        _navMeshAgent.SetDestination(targetVector);
      
    }
    public void DestinationReached()
    {
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance + 1f)
        {
            Debug.Log("destinationReached has been reached");
            reachedFinalDestination = true;
        }
    }
}