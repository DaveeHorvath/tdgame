using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosition : MonoBehaviour
{
    public static GridPosition instance;
    public Grid grid;
    public Vector2Int debugTop;
    public Vector2Int debugBot;

    private void Start()
    {
        instance = this;
    }

    public Vector3Int getPos(Vector3 pos)
    {
        return grid.WorldToCell(pos);
    }
}
