using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDishManager : MonoBehaviour
{
    GameObject emptyDish;//empty petri dish
    GameObject fullDish;//filled petri dish
    GameObject grownDish;//petri dish with mycelium grown

    GameObject gills;// gills

    void Start() 
    {
        emptyDish = gameObject.transform.GetChild(0).gameObject;
        fullDish = gameObject.transform.GetChild(1).gameObject;
        grownDish = gameObject.transform.GetChild(2).gameObject;
    }

    public void fillDish()//put the gills in the dish
    {
        emptyDish.SetActive(false);//turn off empty dish
        fullDish.SetActive(true);//turn on dish with gills

        //gills.SetActive(false);
    }

    public void GrowDish()
    {
        fullDish.SetActive(false);//turn off dish with gills
        grownDish.SetActive(true);//turn on dish with gills and mycelium
        //grownDish.transform.parent = this.transform;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Gills")
        {
            fillDish();
            Destroy(other.gameObject);
        }
    }
}
