using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TowerBaseAttack))]
public class TowerDamageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TowerBaseAttack tower = (TowerBaseAttack)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Generate Grid Values"))
        {
            tower.gridPosition = FindObjectOfType<GridPosition>().grid.WorldToCell(tower.transform.position);
            tower.GenerateAttackArea();
        }
    }
}