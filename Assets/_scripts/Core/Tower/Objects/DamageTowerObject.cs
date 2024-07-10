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

    // todo fancy editor script at some point
    [Header("Pattern")]
    public List<GridArea> _relativepositions;
    public List<float> _damage;
}
