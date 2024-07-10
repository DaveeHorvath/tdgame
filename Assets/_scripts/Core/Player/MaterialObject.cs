// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialObject", menuName = "MaterialObject")]
public class MaterialObject : ScriptableObject
{
    [Header("General")]
    [SerializeField]
    public string _name;
    [SerializeField]
    public string _description;
    [Header("Visual")]
    [SerializeField]
    public Sprite _sprite;
}
