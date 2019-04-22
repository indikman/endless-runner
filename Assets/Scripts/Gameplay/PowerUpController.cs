using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public Utils.powerup powerupType;

    public float[] laneXValues;

    public void setPowerUp(Utils.powerup type){
        this.gameObject.SetActive(true);
        powerupType = type;
        
        if(laneXValues.Length > 0)
            transform.position = new Vector3(laneXValues[Random.Range(0, laneXValues.Length)], transform.position.y, transform.position.z);
    }

    public void clearPowerUp(){
        this.gameObject.SetActive(false);
    }
}
