using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenerateItemPositions : MonoBehaviour
{
    public Transform parent;
    public GameObject prefab;

    public float min = -5f;
    public float max = 5f;
    public float delta = 0.2f;
    public float[] xPositions;

    public void generatePositions()
    {
        for(int i=0; i<xPositions.Length; i++){
            int y=0;
            for(float x = min; x < max; x+=delta){
                //GameObject obj = Instantiate(prefab, new Vector3(xPositions[i], 0, x), Quaternion.identity);
                GameObject obj = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                obj.name = "Lane " + i + " - item - " + y;
                obj.transform.SetParent(parent, true);
                obj.transform.localPosition = new Vector3(xPositions[i], 0, x);
                y++;
            }
        }
    }

}
