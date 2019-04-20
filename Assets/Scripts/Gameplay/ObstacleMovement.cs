using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves in the Z axix towards 0 and destroys itself after reaching the destroy point
public class ObstacleMovement : MonoBehaviour
{
    public Vector3 movementDirection = new Vector3(0, 0, -1);
    //public float speed = 0.0f;
    public float destroyPoristionZ = -10.0f;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= destroyPoristionZ)
        {
            //do movement
            transform.Translate(movementDirection * GlobalVariables.obstacleMovementSpeed * Time.deltaTime);
        }
        else
        {
            GameObject.Destroy(gameObject);
            //
        }
    }
}
