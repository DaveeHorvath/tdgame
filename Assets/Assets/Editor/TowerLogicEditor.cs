using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TowerLogical))]
public class TowerLogicEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TowerLogical tower = (TowerLogical)target;
        DrawDefaultInspector();
        if (GUILayout.Button("generate grid pos"))
        {
            tower.gridPosition = GameObject.FindObjectOfType<GridPosition>().grid.WorldToCell(tower.transform.position);
        }
    }
}

