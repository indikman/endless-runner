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
        ResetGame();
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

        Utils.isRunning = true;
    }


    void Update()
    {
        Utils.OBSTACLE_SPEED = speed;
        Utils.SPEED = floorSpeed;

        //Utils.score = (int)scoretemp;
    }
    
    float scoretemp;
    void FixedUpdate(){
        if(Utils.isRunning){
            scoretemp += (Utils.scoreMultiplier * Utils.SPEED/100);
            if(scoretemp >= 1){
                scoretemp = 0;
                Utils.score++;
                PreferencesManager.AppendScore(1);
            }
        }
            
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

            //Score for UI
            Utils.coin_count += (Utils.isScoreBoost == true ? Utils.coinMultiplier * 2 : Utils.coinMultiplier);
            Utils.score += (Utils.isScoreBoost == true ? Utils.coinMultiplier * 2 : Utils.coinMultiplier);

            //Score for API
            

        }
        else if (hitObject.GetComponent<ItemController>().itemType == Utils.item.obstacle_jump)
        {
            //game over if not shield on
            if(!Utils.isShield)
                GameOver();

        }
        else if (hitObject.GetComponent<ItemController>().itemType == Utils.item.obstacle_slide)
        {
            //if player is sliding - no worries, else, gameover
            if(!Utils.isShield || !Utils.isSliding)
                GameOver();
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
        else if (hitObject.GetComponent<PowerUpController>().powerupType == Utils.powerup.score)
        {
            //apply magnet
            startScoreBoost();
        }
        else if (hitObject.GetComponent<PowerUpController>().powerupType == Utils.powerup.coin)
        {
            //apply coin
            startCoinBoost();
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

    public void generateNextPowerUp(GameObject powerUp)
    {
        //powerup!
        if (Random.Range(0, 100) >= Utils.POWERUP_PROBABILITY_THRESHOLD)
        {
            //spawn a random powerup
            powerUp.GetComponent<PowerUpController>().setPowerUp((Utils.powerup)Random.Range(0, System.Enum.GetValues(typeof(Utils.powerup)).Length));
        }
    }


    //POWER UPS
    //BOOST
    private Coroutine boost_rouotine;
    public void startBoost()
    {
        if (boost_rouotine != null)
        {
            // StopCoroutine(boost_rouotine);
        }
        boost_rouotine = StartCoroutine(start_boost());
    }
    IEnumerator start_boost()
    {

        //set current speed to temp
        float tempSpeed = speed;
        float tempFloorSpeed = floorSpeed;
        Utils.isShield = true;

        speed += Utils.HIGH_SPEED_ADDITION;
        floorSpeed += Utils.HIGH_SPEED_ADDITION;
        yield return new WaitForSeconds(Utils.boostTime);
        speed = tempSpeed;
        floorSpeed = tempFloorSpeed;
        Utils.isShield = false;
    }

    //Magnet
    private Coroutine scoreboost_rouotine;
    public void startScoreBoost()
    {
        if (scoreboost_rouotine != null)
        {
            StopCoroutine(scoreboost_rouotine);
        }
        scoreboost_rouotine = StartCoroutine(start_scoreboost());
    }

    IEnumerator start_scoreboost()
    {
        Utils.isScoreBoost = true;
        yield return new WaitForSeconds(Utils.scoreBoostTime);
        Utils.isScoreBoost = false;
    }

    private void startCoinBoost()
    {
        Utils.coin_count += Utils.coinBoostValue;
    }

    //Shield
    private Coroutine shield_rouotine;
    public void startShield()
    {
        if (shield_rouotine != null)
        {
            StopCoroutine(shield_rouotine);
        }
        shield_rouotine = StartCoroutine(start_shield());
    }
    IEnumerator start_shield()
    {
        Utils.isShield = true;
        yield return new WaitForSeconds(Utils.shieldTime);
        Utils.isShield = false;
    }

    void GameOver()
    {
        GetComponent<CameraController>().Shake();
        speed = 0;
        floorSpeed = 0;
        Utils.isRunning = false;
    }


    public void ResetGame()
    {
        isPlaying = false;
        Utils.isRunning = false;
        speed = Utils.START_SPEED;
        floorSpeed = Utils.START_SPEED;



        Utils.score = 0;
        scoretemp = 0;
        Utils.isShield = false;

        StartCoroutine(GameStart());
    }

}
