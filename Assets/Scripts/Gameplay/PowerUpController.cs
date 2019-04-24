using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public Utils.powerup powerupType;

    public float[] laneXValues;
    public pItem[] items;

    [System.Serializable]
    public class pItem{
        public Utils.powerup type;
        public GameObject obj;
    }

    public void setPowerUp(Utils.powerup type){
        this.gameObject.SetActive(true);
        powerupType = type;

        //enable the type obj
        foreach(pItem item in items){
            if(powerupType == item.type)
                item.obj.SetActive(true);
        }
        
        if(laneXValues.Length > 0)
            transform.position = new Vector3(laneXValues[Random.Range(0, laneXValues.Length)], transform.position.y, transform.position.z);
    }

    public void clearPowerUp(){
        this.gameObject.SetActive(false);
        foreach(pItem item in items){
            item.obj.SetActive(false);
        }
    }
}
