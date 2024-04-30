// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MinionTower", menuName = "Towers/MinionTowers")]
public class MinionTowerObject : TowerObject
{
    [Header("Minion")]
    [SerializeField]
    private List<MinionObject> _minions;
}
