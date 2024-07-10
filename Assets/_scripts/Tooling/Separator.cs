using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
public class Separator : PropertyAttribute
{
    public readonly float Height;
    public readonly float Spacing;
    public Separator(float height = 2, float spacing = 10)
    {
        Height = height;
        Spacing = spacing;
    }
}
