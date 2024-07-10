using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GridArea))]
public class GridAreaEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //grid = GameObject.FindGameObjectWithTag("actiongrid").GetComponent<Grid>();
        DrawDefaultInspector();
    }
}
