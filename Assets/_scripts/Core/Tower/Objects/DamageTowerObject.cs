// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageTower", menuName = "Towers/AttackTower")]
public class DamageTowerObject : TowerObject
{
    [Header("Damage")]
    [SerializeField]
    private EDamageType _damagetype;
    [SerializeField]
    private float _attackdamage;
    [SerializeField]
    private float _reloadtime;
    public float reload => _reloadtime;
    private ETowerType _towertype = ETowerType.Damage;

    // todo fancy editor script at some point
    [Header("Pattern")]
    [SerializeField]
    private List<Vector2> _relativepoisitions;
    [SerializeField]
    private Dictionary<Vector2, float> _damagebonus;
    public Dictionary<Vector2, float> damageBonus => _damagebonus;
}
