using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManagement : MonoBehaviour
{
    public GameObject powerUp;
    
    public Vector3 movementDirection = new Vector3(0, 0, -1);
    public float resetPositionZ = 0f; 
    public Vector3 startPosition;

    void Start(){
        startPosition = powerUp.transform.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariables.isRunning){
            powerUp.transform.Translate(movementDirection * GlobalVariables.platformMovementSpeed * Time.deltaTime);
        }

        if(powerUp.transform.position.z <= resetPositionZ){
            powerUp.transform.position = startPosition;
            powerUp.GetComponent<PowerUpController>().setPowerUp(Utils.powerup.boost); // TEST
        }
    }
}
