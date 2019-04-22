using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    public platformType type;

    public GameObject platform1;
    public GameObject platform2;

    public float resetPositionZ = -60f;
    public Vector3 startPosition;


    public Vector3 movementDirection = new Vector3(0, 0, -1);

    private int currentPlatform = 1;


    // Start is called before the first frame update
    void Start()
    {
        currentPlatform = 1;
        platform1.transform.position = startPosition;
        platform2.transform.position = new Vector3(startPosition.x, startPosition.y, calculatePlatformZ(platform1, platform2));

        if (type == platformType.item)
        {
            GetComponent<GameplayController>().clearItemPanel(platform1); // starting panel will be cleared
            GetComponent<GameplayController>().refreshItems(platform2);
        }


    }

    // Update is called once per frame
    void Update()
    {
        platform1.transform.Translate(movementDirection * GlobalVariables.platformMovementSpeed * Time.deltaTime);
        platform2.transform.Translate(movementDirection * GlobalVariables.platformMovementSpeed * Time.deltaTime);

        if (platform1.transform.position.z <= resetPositionZ)
        {
            //reset platform to 2
            currentPlatform = 2;
            platform1.transform.position = new Vector3(startPosition.x, startPosition.y, calculatePlatformZ(platform2, platform1));
            if (type == platformType.item)
            {
                GetComponent<GameplayController>().refreshItems(platform1);
            }
        }

        if (platform2.transform.position.z <= resetPositionZ)
        {
            //reset platform to 2
            currentPlatform = 2;
            platform2.transform.position = new Vector3(startPosition.x, startPosition.y, calculatePlatformZ(platform1, platform2));
            if (type == platformType.item)
            {
                GetComponent<GameplayController>().refreshItems(platform2);
            }
        }
    }

    float calculatePlatformZ(GameObject p1, GameObject p2)
    {
        return p1.transform.position.z + p1.GetComponent<Renderer>().bounds.size.z / 2 + p2.GetComponent<Renderer>().bounds.size.z / 2;
    }

    [System.Serializable]
    public enum platformType
    {
        floor, item, environment
    }
}
