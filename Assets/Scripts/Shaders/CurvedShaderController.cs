using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CurvedShaderController : MonoBehaviour
{

    [Header("Offset")]
    [SerializeField]
    private Vector4 offset = new Vector4(0,0,0,0);

    [SerializeField]
    private float distance = 200;

    [SerializeField]
    private bool isDevelop = false;

    public static void SetValues(Vector4 _offset, float _distance)
    {
        Shader.SetGlobalVector("_QOffset", _offset);
        Shader.SetGlobalFloat("_Dist", _distance);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        if(!isDevelop){
            SetValues(offset, distance);
        }else{
            SetValues(new Vector4(0,0,0,0), 100);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(!isDevelop){
            SetValues(offset, distance);
        }else{
            SetValues(new Vector4(0,0,0,0), 100);
        }
    }

    public void SetOffset(Vector4 curvature){
        offset = curvature;
    }

}
