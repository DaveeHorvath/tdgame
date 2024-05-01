// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseAttack : TowerLogical
{
    [SerializeField]
    private bool canAttack;
    private DamageTowerObject _damageTower;

    public override void Awake()
    {
        base.Awake();
        if (base._tower.type == ETowerType.Damage)
            Debug.LogException(new System.Exception("Incorrect tower type loaded"));
        _damageTower = _tower as DamageTowerObject;
        canAttack = true;
    }

    public override bool Action()
    {
        if (!base.Action())
            return false;
        if (canAttack && IsEnemyInRange())
            Attack();
        return (true);
    }

    public virtual void Attack()
    {
        foreach (KeyValuePair<Vector2, float> field in _damageTower.damageBonus)
            Debug.Log(field.Value.ToString() + " damage taken on " + field.Key.ToString());
        StartCoroutine("startAttack");
    }

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
