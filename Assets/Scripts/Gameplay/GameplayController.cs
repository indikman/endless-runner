using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{

    public GameObject Obstacle;
    public float ObstacleSpawnZ;

    public float speed = 10f;

    public float floorSpeed = 0f;

    void Start()
    {
        ////StartCoroutine(SpawnObstacles());
    }

    public IEnumerator SpawnObstacles()
    {
        while (true)
        {

            GameObject obj = Instantiate(Obstacle, new Vector3(Random.Range(-4, 4), 0, ObstacleSpawnZ), Quaternion.identity);
            //obj.GetComponent<ObstacleMovement>().speed = speed;

            yield return new WaitForSeconds(1.0f);
        }
    }

    void Update()
    {
        GlobalVariables.obstacleMovementSpeed = speed;
        GlobalVariables.platformMovementSpeed = floorSpeed;
    }


    public void refreshItems(GameObject itemPanel){
        itemPanel.GetComponent<ItemsManagement>().applyItemPattern(1, 50);
        itemPanel.GetComponent<ItemsManagement>().applyItemPattern(2, 50);
        itemPanel.GetComponent<ItemsManagement>().applyItemPattern(3, 50);
    }

    public void hitItems(GameObject hitObject){
        if(hitObject.GetComponent<ItemController>().itemType == Utils.item.coin){
            //Got a Coin!
            GetComponent<ItemController>().clear();

            //Particl

            //Score

        }else if (hitObject.GetComponent<ItemController>().itemType == Utils.item.obstacle_jump){
            //game over
        }else if (hitObject.GetComponent<ItemController>().itemType == Utils.item.obstacle_slide){
            //if player is sliding - no worries, else, gameover

        }

    }
}
