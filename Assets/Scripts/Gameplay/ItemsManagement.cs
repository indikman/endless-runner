using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManagement : MonoBehaviour
{

    public int hardness = 0; //0-10

    //private Transform[] items;
    List<GameObject> objs;

    void Start()
    {
        getElements();
    }

    public void getElements()
    {
        //items = GetComponentsInChildren<Transform>();
        objs = new List<GameObject>();
        foreach (Transform t in transform)
        {
            objs.Add(t.gameObject);
        }
        Debug.Log(gameObject.name + "  -  " + objs.Count);
    }

    //probability parameter
    // 0---------<coin probability>--------X--------<obstacle probability>------100 //
    //larger the range larger the probability
    private string itemPatternGenerate(int x)
    {

        string pattern = "c";//start with an empty
        int rnd;

        for (int i = 0; i < 4; i++) //since the start is given earlier
        {
            rnd = Random.Range(0, 100);
            pattern += (rnd >= x ? ",c" : ",o");
        }

        return pattern;

    }

    public void applyItemPattern(int lane, int x)
    { //lane 1,2,3

        string pattern = itemPatternGenerate(x);
        string[] itemstring = pattern.Split(',');
        //Debug.Log("lane - " + lane + " - " + pattern);


        for (int i = 0; i < itemstring.Length; i++)
        {
            // Debug.Log(itemstring.Length);

            if (itemstring[i] == "c")
            {
                if (Random.Range(0, 100) >= Utils.COIN_THRESHOLD)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        //Assign a coin
                        objs[j + (10 * i) + (lane - 1) * GlobalVariables.itemsInALane].gameObject.GetComponent<ItemController>().setItem("coin");
                    }
                }
                else
                {
                    //nothing
                    for (int j = 0; j < 10; j++)
                    {
                        objs[j + (10 * i) + (lane - 1) * GlobalVariables.itemsInALane].gameObject.GetComponent<ItemController>().setItem("empty");
                    }
                }

            }
            else if (itemstring[i] == "o")
            {
                for (int j = 0; j < 10; j++)
                {
                    //randomly assign an obstacle
                    if (Random.Range(0, 100) >= Utils.OBSTACLE_THRESHOLD)
                    {
                        //obstacle
                        objs[j + (10 * i) + (lane - 1) * GlobalVariables.itemsInALane].gameObject.GetComponent<ItemController>().setItem("obstacle");
                    }
                    else
                    {
                        //nothing
                        objs[j + (10 * i) + (lane - 1) * GlobalVariables.itemsInALane].gameObject.GetComponent<ItemController>().setItem("empty");
                    }
                }
            }



            //objs[i + (itemstring.Length * lane)].gameObject.GetComponent<ItemController>().setItem(itemstring[i]); //Item Controller will manage the rest
        }
    }

    public void clearObstacles(){
        foreach(GameObject o in objs){
            o.GetComponent<ItemController>().setItem("empty");
        }
    }
}
