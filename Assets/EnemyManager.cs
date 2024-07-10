using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Vector3Int> positions;
    public GridArea area;
    public Enemy enemy;
    // Update is called once per frame
    void Update()
    {
        if (area.isInArea(GridPosition.instance.grid.WorldToCell(enemy.transform.position)))
            Debug.Log("thing");
    }
}
