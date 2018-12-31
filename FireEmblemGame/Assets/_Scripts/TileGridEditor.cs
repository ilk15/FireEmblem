using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileGrid))]
[CanEditMultipleObjects]
public class TileGridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TileGrid maker = (TileGrid)target;
        if (GUILayout.Button("make grid"))
        {
            maker.make();
        }
    }
}
