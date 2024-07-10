// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialObject", menuName = "MaterialObject")]
public class MaterialObject : ScriptableObject
{
    [Header("General")]
    [SerializeField]
    private string _name;
    [SerializeField]
    private string _description;
    [Header("Visual")]
    [SerializeField]
    private Sprite _sprite;
}
