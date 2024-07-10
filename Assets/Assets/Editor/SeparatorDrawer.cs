using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Separator))]
public class SeparatorDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect pos)
    {
        // get attribute
        Separator sep = attribute as Separator;
        // make calc
        Rect rect = new Rect(pos.xMin, pos.yMin + sep.Spacing, pos.xMax - 5, sep.Height);
        //draw
        EditorGUI.DrawRect(rect, Color.red);
    }

    public override float GetHeight()
    {
        Separator sep = attribute as Separator;
        return sep.Height + 2 * sep.Spacing;
    }
}
