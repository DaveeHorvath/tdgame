using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Vector3Int> positions;
    public static EnemyManager instance;
    //public GridArea area;
    public Enemy enemy;
    // Update is called once per frame

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        /*if (area.isInArea(GridPosition.instance.grid.WorldToCell(enemy.transform.position)))
            Debug.Log("thing");*/
    }

    public void TakeDamage(float amount, GridArea area)
    {
        if (area.isInArea(GridPosition.instance.getPos(enemy.transform.position)))
            Debug.Log(amount.ToString() + " damage taken on " + GridPosition.instance.getPos(enemy.transform.position));
    }

}
