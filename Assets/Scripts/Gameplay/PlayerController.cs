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


    //other private variables
    private bool isUp;

    void Start()
    {
        floorPos = transform.position.y;
        isUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

//    Sequence jumpEase = DOTween.Sequence();


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

    public void downOrSlide(){
        if(isUp){
            //jumpEase.Kill(); // remove the current jumping animation

            transform.DOKill(true);
            transform.DOMoveY(floorPos, downTime).OnComplete(()=>{
                    isUp = false;
                });

            //transform.position = new Vector3(transform.position.x, floorPos, transform.position.z);
            //isUp = false;
           // Debug.Log("Change!");
        }else{
            //Slide animation or slide down bool
        }
    }

}
