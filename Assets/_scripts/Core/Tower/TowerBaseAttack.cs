// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direction
{
    North, West, South, East
}

public class TowerBaseAttack : TowerLogical
{
    [SerializeField]
    private bool canAttack;
    [SerializeField]
    private DamageTowerObject _damageTower;
    private List<GridArea> _attackareas;
    [SerializeField]
    private bool debug;
    [SerializeField]
    private direction _direction;

    private void Awake()
    {
        onAwake();
    }

    /*
     * exits if not the correct type of tower
     */
    public override void onAwake()
    {
        _tower = _damageTower;
        if (_damageTower.type != ETowerType.Damage)
            Debug.LogException(new System.Exception("Incorrect tower type loaded"));
        if (_damageTower._damage.Count != _damageTower._relativepositions.Count)
            Debug.LogException(new System.Exception("Invalid damage and area setup"));
        base.onAwake();
        canAttack = true;
        GenerateAttackArea();
    }

    /*
     * stops if cant pay resource
     * otherwise tries to attack the square
     */
    public override bool Action()
    {
        if (!base.Action())
            return false;
        if (canAttack && IsEnemyInRange())
            Attack();
        return (true);
    }

    /*
     * function to override for all the attacks extra
     * damages all squares by default in pattern
     */
    public virtual void Attack()
    {
        for (int i = 0;i < _attackareas.Count;i++)
        {
            EnemyManager.instance.TakeDamage(_damageTower._damage[i], _attackareas[i]);
        }
        StartCoroutine("StartAttack");
    }

    /*
     * util func to see if attacks are even needed
     * ToDo
     */
    private bool IsEnemyInRange()
    {
        return true;
    }

    /*
     * Base attack function, write better ones for more intresting behavior
     * charging up, bursts of attacks and such
     */
    IEnumerator StartAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(_damageTower.reload);
        canAttack = true;
    }

    /*
     * sets up grid for attacks
     * used for display as well
     */
    public void GenerateAttackArea()
    {
        _attackareas = new List<GridArea>(_damageTower._relativepositions.Count);
        for (int i = 0; i < _damageTower._relativepositions.Count; i++)
        {
            GridArea a = new GridArea(gridPosition, gridPosition);
            switch(_direction)
            {
                case direction.North:
                    a.bottomright += _damageTower._relativepositions[i].bottomright;
                    a.topleft += _damageTower._relativepositions[i].topleft;
                    break;
                case direction.South:
                    a.bottomright -= _damageTower._relativepositions[i].bottomright;
                    a.topleft -= _damageTower._relativepositions[i].topleft;
                    break;
                case direction.West:
                    a.topleft += new Vector3Int(_damageTower._relativepositions[i].topleft.y, _damageTower._relativepositions[i].topleft.x);
                    a.bottomright += new Vector3Int(_damageTower._relativepositions[i].bottomright.y, _damageTower._relativepositions[i].bottomright.x);
                    break;
                case direction.East:
                    a.topleft -= new Vector3Int(_damageTower._relativepositions[i].topleft.y, _damageTower._relativepositions[i].topleft.x);
                    a.bottomright -= new Vector3Int(_damageTower._relativepositions[i].bottomright.y, _damageTower._relativepositions[i].bottomright.x);
                    break;
            }
            _attackareas.Add(a);
        }
    }

    /*
     * Debug view where the tiles attacked by the tower get a little wireframe
     * more color and more squares = more damage
     */
    private void OnDrawGizmos()
    {
        if (debug)
        {
            Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.black, Color.magenta };
            int i = 0;
            foreach (GridArea attackarea in _attackareas)
            {
                Gizmos.color = colors[i % 6];
                for (int x = attackarea.topleft.x; x < attackarea.bottomright.x; x++)
                {
                    for (int y = attackarea.bottomright.y; y < attackarea.topleft.y; y++)
                    {
                        Gizmos.DrawWireCube(FindObjectOfType<GridPosition>().grid.CellToWorld(new Vector3Int(x, y, 0)) + FindObjectOfType<GridPosition>().grid.cellSize / 2, FindObjectOfType<GridPosition>().grid.cellSize - new Vector3(i * 0.05f, i* 0.05f));
                    }
                }
                i++;
            }
        }
    }
}
