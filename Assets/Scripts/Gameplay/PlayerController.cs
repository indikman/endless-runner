using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("Move Positions")]
    public float[] movePositionsX;
    public float sideMoveTime;

    [Header("Jump")]
    public float jumpPeak;
    public float jumpTime;
    public float floorPos;

    [Header("Down or Slide")]
    public float downTime;
    public float slideTime;

    [Header("Game Controller")]
    public GameObject GameController;


    //other private variables
    private bool isUp;

    void Start()
    {
        floorPos = transform.position.y;
        isUp = false;
        Utils.isSliding = false;
    }


    public void movePlayerSide(int pos)
    {
        transform.DOMoveX(movePositionsX[pos], sideMoveTime).SetEase(Ease.OutCirc);
    }

    public void jump(){
        if(!isUp){
            isUp = true;
            transform.DOMoveY(jumpPeak, jumpTime).SetEase(Ease.OutSine).OnComplete(()=>{
                transform.DOMoveY(floorPos, jumpTime).SetEase(Ease.InSine).OnComplete(()=>{
                    isUp = false;
                });
            });
        }
    }

    Coroutine slide_routine;
    public void downOrSlide(){
        if(isUp){
            //remove the current jumping animation

            transform.DOKill(true);
            transform.DOMoveY(floorPos, downTime).OnComplete(()=>{
                    isUp = false;
                });

        }else if(!Utils.isSliding){
            //Slide animation or slide down bool
            if(slide_routine!=null){
                StopCoroutine(slide_routine);
            }
            slide_routine = StartCoroutine(slideRouting());
        }
    }

    IEnumerator slideRouting(){
        Utils.isSliding = true;
        yield return new WaitForSeconds(slideTime);
        Utils.isSliding = false;
        yield return null;
    }



    //COLLISIONS
    void OnTriggerEnter(Collider other){
        if(other.tag == Utils.ITEM_TAG){
            //pass collider object to game comtroller
            GameController.GetComponent<GameplayController>().hitItems(other.gameObject);
        }else if (other.tag == Utils.POWERUP_TAG){
            GameController.GetComponent<GameplayController>().hitPowerUp(other.gameObject);
        }
    }

}
