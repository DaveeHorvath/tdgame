using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridArea
{
    public Vector3Int topleft;
    public Vector3Int bottomright;
    public bool debug;

    public GridArea (Vector3Int _topleft, Vector3Int _bottomright)
    {
        topleft = _topleft;
        bottomright = _bottomright;
    }

    public bool isInArea(Vector3Int pos)
    {
        return (topleft.x <= pos.x && topleft.y >= pos.y && bottomright.x >= pos.x && bottomright.y <= pos.y);
    }
}
