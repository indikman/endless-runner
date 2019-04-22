using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject player;

    public float touchThreshold = 20f;

    void Start()
    {
        Utils.current = Utils.lane.middle;
    }

    private Vector2 touchStart, touchEnd;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftMovement();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightMovement();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upMovement();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downMovement();
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
                touchEnd = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                touchEnd = touch.position;

                //check for swipe
                if (movementX() > touchThreshold && movementX() > movementY())
                {
                    if (touchEnd.x - touchStart.x > 0)
                    {
                        rightMovement();
                    }
                    else if (touchEnd.x - touchStart.x < 0)
                    {
                        leftMovement();
                    }
                }

                if (movementY() > touchThreshold && movementY() > movementX())
                {
                    if (touchEnd.y - touchStart.y > 0)
                    {
                        upMovement();
                    }
                    else if (touchEnd.y - touchStart.y < 0)
                    {
                        downMovement();
                    }
                }

            }
        }

    }

    float movementX()
    {
        return Mathf.Abs(touchEnd.x - touchStart.x);
    }

    float movementY()
    {
        return Mathf.Abs(touchEnd.y - touchStart.y);
    }


    void leftMovement()
    {
        if (GlobalVariables.isRunning)
        {
            //jumpleft
            if (Utils.current == Utils.lane.middle)
            {
                GetComponent<CameraController>().moveCameraSide(0);
                player.GetComponent<PlayerController>().movePlayerSide(0);
                Utils.current = Utils.lane.left;
            }
            else if (Utils.current == Utils.lane.right)
            {
                GetComponent<CameraController>().moveCameraSide(1);
                player.GetComponent<PlayerController>().movePlayerSide(1);
                Utils.current = Utils.lane.middle;
            }
        }
    }

    void rightMovement()
    {

        //jumpright
        if (GlobalVariables.isRunning)
        {
            if (Utils.current == Utils.lane.middle)
            {
                GetComponent<CameraController>().moveCameraSide(2);
                player.GetComponent<PlayerController>().movePlayerSide(2);
                Utils.current = Utils.lane.right;
            }
            else if (Utils.current == Utils.lane.left)
            {
                GetComponent<CameraController>().moveCameraSide(1);
                player.GetComponent<PlayerController>().movePlayerSide(1);
                Utils.current = Utils.lane.middle;
            }
        }

    }

    void upMovement()
    {
        if (GlobalVariables.isRunning)
        {
            player.GetComponent<PlayerController>().jump();
        }
    }

    void downMovement()
    {
        if (GlobalVariables.isRunning)
        {
            //slide or get to ground
            player.GetComponent<PlayerController>().downOrSlide();
        }
    }
}
