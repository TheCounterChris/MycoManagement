using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT GOES ON THE MUSHROOM OBJECT
public class GillExtraction : MonoBehaviour
{
    public GameObject gills;//gills model
    public GameObject[] cutPoints = new GameObject[8];//list of the points you have to cut
    //public GameObject tablePlace;//where the gills go after they are cut off of the mushroom

    Transform trashCan;//trashcan, where the mushroom goes after gills are removed
    Transform tablePlace;//table place, where the gills go after they are cut off of the mushroom

    int numCuts = 0;//how many points have been cut

    // Start is called before the first frame update
    void Start()
    {
        trashCan = GameObject.Find("Trashcan").transform;//find the trashcan
        tablePlace = GameObject.Find("TablePlace").transform;//find the table place
    }


    public void UpdateCut()//what to do when one point is cut
    {
        numCuts++;//increase number of points cut by one
        Debug.Log("Number of cuts: " + numCuts);//print

        if(numCuts >= cutPoints.Length)//if all of the points are cut
        {
            Debug.Log("They all got cut");//print
            gills.transform.parent = null;//remove the gills from the mushroom
            
            gameObject.transform.position = trashCan.position;//put the mushroom in the trashcan
            gameObject.transform.parent = null;//release the mushroom from the robot's hold
            this.GetComponent<Rigidbody>().useGravity = true;//turn on gravity for the mushroom
            this.GetComponent<RotateObject>().enabled = false;//turn of the rotation script

            gills.transform.position = tablePlace.transform.position;//move the gills to the table
            gills.transform.Rotate(90f, 0f, 0f, Space.World);//turn the gills right side up
            //gills.AddComponent<Rigidbody>();
        }
    }
}//class
