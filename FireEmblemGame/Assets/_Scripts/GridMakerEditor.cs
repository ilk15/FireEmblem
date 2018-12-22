using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridMaker))]
[CanEditMultipleObjects]
public class GridMakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridMaker maker = (GridMaker)target;
        if (GUILayout.Button("make grid"))
        {
            maker.make();
        }
    }
}
