using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// to change how the inspector look
/// </summary>
[CustomEditor(typeof(RoadWithBackGenerator))]
public class RoadWithBackGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RoadWithBackGenerator myScript = (RoadWithBackGenerator)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.BuildRoad();
        }
    }
}
