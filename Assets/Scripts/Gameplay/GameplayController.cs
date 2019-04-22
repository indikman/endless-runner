/*

© Indika Wijesooriya
Dedicated to all the victims of Sri Lankan Explosions 21 / 04 / 2019


 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{

    public GameObject Obstacle;
    public float ObstacleSpawnZ;

    public float speed = 10f;
    public float floorSpeed = 10f;

    bool isPlaying = false;

    void Start()
    {
        // Game Reset
        resetGame();


    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("3");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("GO!");

        GlobalVariables.isRunning = true;
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


    public void refreshItems(GameObject itemPanel)
    {
        itemPanel.GetComponent<ItemsManagement>().applyItemPattern(1, Utils.COIN_TO_OBSTACLE_THRESHOLD);
        itemPanel.GetComponent<ItemsManagement>().applyItemPattern(2, Utils.COIN_TO_OBSTACLE_THRESHOLD);
        itemPanel.GetComponent<ItemsManagement>().applyItemPattern(3, Utils.COIN_TO_OBSTACLE_THRESHOLD);
    }

    public void clearItemPanel(GameObject itemPanel)
    {
        itemPanel.GetComponent<ItemsManagement>().clearObstacles();
    }

    public void hitItems(GameObject hitObject)
    {
        if (hitObject.GetComponent<ItemController>().itemType == Utils.item.coin)
        {
            //Got a Coin!
            hitObject.GetComponent<ItemController>().clear();

            //Particl

            //Score

        }
        else if (hitObject.GetComponent<ItemController>().itemType == Utils.item.obstacle_jump)
        {
            //game over
            GetComponent<CameraController>().Shake();
            speed = 0;
            floorSpeed = 0;
            GlobalVariables.isRunning = false;

        }
        else if (hitObject.GetComponent<ItemController>().itemType == Utils.item.obstacle_slide)
        {
            //if player is sliding - no worries, else, gameover

        }

    }

    public void hitPowerUp(GameObject hitObject)
    {
        hitObject.GetComponent<PowerUpController>().clearPowerUp();
        Debug.Log(hitObject.GetComponent<PowerUpController>().powerupType.ToString());
        if (hitObject.GetComponent<PowerUpController>().powerupType == Utils.powerup.boost)
        {
            //apply boost
            startBoost();
        }
        else if (hitObject.GetComponent<PowerUpController>().powerupType == Utils.powerup.magnet)
        {
            //apply magnet
            startMagnet();
        }
        else if (hitObject.GetComponent<PowerUpController>().powerupType == Utils.powerup.coin)
        {
            //apply coin
            Debug.Log("coin!");
        }
        else if (hitObject.GetComponent<PowerUpController>().powerupType == Utils.powerup.shield)
        {
            //apply shield
            startShield();
        }
        else if (hitObject.GetComponent<PowerUpController>().powerupType == Utils.powerup.rb)
        {
            //add RB
        }
    }


    //POWER UPS
    //BOOST
    private Coroutine boost_rouotine;
    public void startBoost(){
        if(boost_rouotine!=null){
           // StopCoroutine(boost_rouotine);
        }
        boost_rouotine = StartCoroutine(start_boost());
    }
    IEnumerator start_boost(){
        speed += Utils.HIGH_SPEED_ADDITION;
        floorSpeed += Utils.HIGH_SPEED_ADDITION;
        yield return new WaitForSeconds(Utils.boostTime);
        speed -= Utils.HIGH_SPEED_ADDITION;
        floorSpeed -= Utils.HIGH_SPEED_ADDITION;
    }

    //Magnet
    private Coroutine magnet_rouotine;
    public void startMagnet(){
        if(magnet_rouotine!=null){
            StopCoroutine(magnet_rouotine);
        }
        magnet_rouotine = StartCoroutine(start_magnet());
    }
    IEnumerator start_magnet(){
        yield return new WaitForSeconds(Utils.magnetTime);
    }

    //Shield
    private Coroutine shield_rouotine;
    public void startShield(){
        if(shield_rouotine!=null){
            StopCoroutine(shield_rouotine);
        }
        shield_rouotine = StartCoroutine(start_shield());
    }
    IEnumerator start_shield(){
        yield return new WaitForSeconds(Utils.shieldTime);
    }


    public void resetGame()
    {
        isPlaying = false;
        GlobalVariables.isRunning = false;
        speed = Utils.START_SPEED;
        floorSpeed = Utils.START_SPEED;
        StartCoroutine(GameStart());
    }
}
