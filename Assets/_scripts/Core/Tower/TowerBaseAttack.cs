// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseAttack : TowerLogical
{
    [SerializeField]
    private bool canAttack;
    private DamageTowerObject _damageTower;

    /*
     * exits if not the correct type of tower
     */
    public override void Awake()
    {
        base.Awake();
        if (base._tower.type == ETowerType.Damage)
            Debug.LogException(new System.Exception("Incorrect tower type loaded"));
        _damageTower = _tower as DamageTowerObject;
        canAttack = true;
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
        foreach (KeyValuePair<Vector2, float> field in _damageTower.damageBonus)
            Debug.Log(field.Value.ToString() + " damage taken on " + field.Key.ToString());
        StartCoroutine("startAttack");
    }

    /*
     * util func to see if attacks are even needed
     * ToDo
     */
    private bool IsEnemyInRange()
    {
        return true;
    }

    IEnumerator StartAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(_damageTower.reload);
        canAttack = true;
    }
}
