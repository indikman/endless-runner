using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public GameObject coin;
    public GameObject[] obstacles;
    public TextMesh debug;

    public Utils.item itemType;

    void Start()
    {
        debug.text = "";
    }

    private void setDebugText(string msg)
    {
        debug.text = msg;
    }

    public void setItem(string item){
        clear();
        setDebugText(item);
        if(item=="coin"){
            coin.SetActive(true);
            itemType = Utils.item.coin;
            GetComponent<Collider>().enabled = true;
        }else if(item=="obstacle"){
            obstacles[Random.Range(0,obstacles.Length)].SetActive(true); //enable single obstacle
            //based on the obstacle it will keep track of the obstacle type.
            itemType = Utils.item.obstacle_jump;
            GetComponent<Collider>().enabled = true;
        }
        
    }
    
    public void clear(){
        coin.SetActive(false);
        foreach(GameObject o in obstacles){
            o.SetActive(false);
        }
        GetComponent<Collider>().enabled = false;
    }
}
