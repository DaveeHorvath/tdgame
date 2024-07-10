using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class GridPosition : MonoBehaviour
{
    public static GridPosition instance;
    public Grid grid;

    public void Start()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this);
    }

    public Vector3Int getPos(Vector3 pos)
    {
        return grid.WorldToCell(pos);
    }
}
