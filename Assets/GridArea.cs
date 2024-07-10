using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridArea : MonoBehaviour
{
    public Vector3Int topleft;
    public Vector3Int bottomright;
    public bool debug;

    public bool isInArea(Vector3Int pos)
    {
        return (topleft.x <= pos.x && topleft.y >= pos.y && bottomright.x >= pos.x && bottomright.y <= pos.y);
    }

    private void OnDrawGizmos()
    {
        if  (debug)
        {
            Grid grid = GameObject.FindGameObjectWithTag("actiongrid").GetComponent<Grid>();
            for (int x = topleft.x; x <= bottomright.x; x++)
            {
                for (int y = topleft.y; y <= bottomright.y; y++)
                    Gizmos.DrawWireCube(grid.CellToWorld(new Vector3Int(x, y, 0)), new Vector3(0.25f, 0.25f, 0));
            }
        }
    }

}
