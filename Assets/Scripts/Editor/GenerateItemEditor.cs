using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenerateItemPositions))]
public class GenerateItemEditor : Editor
{
    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        GenerateItemPositions pos = (GenerateItemPositions)target;

        if(GUILayout.Button("Spawn Prefabs")){
            pos.generatePositions();
        }

    }
}
