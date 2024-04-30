// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseTower", menuName = "Towers/")]
public class TowerObject : ScriptableObject
{
    [Header("General")]
    [SerializeField]
    private string _name;
    [SerializeField]
    private string _description;
    private ETowerType _towertype = ETowerType.None;
    public ETowerType type => _towertype;

    [Header("Cost")]
    [SerializeField]
    private Dictionary<MaterialObject, float> _upkeepcost;
    private Dictionary<MaterialObject, float> _purchasecost;

    // todo upgrade path here or child class
    // todo rarity and price
}
