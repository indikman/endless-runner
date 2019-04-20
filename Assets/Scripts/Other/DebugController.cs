using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        txt = text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Text text;

    private static Text txt;

    public static void showDebug(string msg){
        txt.text = msg;
    }
}
