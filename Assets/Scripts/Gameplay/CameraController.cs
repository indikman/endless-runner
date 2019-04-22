using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraController : MonoBehaviour
{
    private Vector3 startPos;

    [Header("Side Movements")]
    public float[] cameraPositions;
    public float movementTime;

    [Header("Jump and Slide")]
    public float upPeak;
    public float upTime, downTime;

    public Transform cam;

    void Start()
    {
        startPos = cam.position;
        isUp = false;
    }

    public void moveCameraSide(int pos)
    {
        //pos 0,1,2 for left, mid, right
        cam.DOMoveX(cameraPositions[pos], movementTime).SetEase(Ease.OutCirc);
    }

    private bool isUp;
    public void moveCameraUp()
    {
        if (!isUp)
        {
            isUp = true;
            cam.DOMoveY(upPeak, upTime).OnComplete(() =>
            {
                cam.DOMoveY(startPos.y, downTime).OnComplete(()=>{isUp = false;});
                
            });
        }

    }

    public void Shake(){
        cam.DOShakePosition(1.0f, 1, 10, 90, false, true);
    }
}
