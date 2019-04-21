using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvatureAnimator : MonoBehaviour
{
    public Vector2 timeRange;
    public Vector2 waitRange;
    public Vector2 xRange;
    public Vector2 yRange;
    
    public float speed;

    private Vector4 curvature;
    private float deltaX;
    private float deltaY;

    public bool isAnim = true;

    private float finalX, finalY;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeAnimation());
    }

    public IEnumerator changeAnimation(){
        while(isAnim){
            yield return new WaitForSeconds(Random.Range(waitRange.x, waitRange.y));

            deltaX = (Random.Range(0f,1f) < 0.5f ? -1:1)* speed/100;
            deltaY = (Random.Range(0f,1f) < 0.5f ? -1:1)* speed/100;
            //Debug.Log("Offset Changed! "  + deltaX + "  " + deltaY);
        }
    }

    // Update is called once per frame
    void Update()
    {

        finalX = Mathf.Clamp(finalX += deltaX, xRange.x, xRange.y);
        
        finalY = Mathf.Clamp(finalY += deltaY, yRange.x, yRange.y);

       /*  if(finalX >= xRange.x && finalX <= xRange.y){
            finalX += deltaX;
        }else{
            if(finalX < xRange.x)
                finalX = xRange.x;
            else if (finalX > xRange.y)
                finalX = xRange.y;
        }

        if(finalY >= yRange.x && finalY <= yRange.y){
            finalY += deltaY;
        }else{
            if(finalY < yRange.x)
                finalY = yRange.x;
            else if (finalY > yRange.y)
                finalY = yRange.y;
        }*/

        curvature = new Vector4(finalX, finalY, 0, 0);

        GetComponent<CurvedShaderController>().SetOffset(curvature);
    }
}
