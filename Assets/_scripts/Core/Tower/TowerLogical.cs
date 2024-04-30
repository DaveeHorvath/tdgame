// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLogical : MonoBehaviour
{
    [SerializeField]
    private protected TowerObject _tower;
    [SerializeField]
    private bool canWork;
    /*
     * on spawn check if the data has been loaded up correctly
     */
    public virtual void Awake()
    {
        if (_tower == null)
            Debug.LogException(new System.Exception("Missing tower object reference"));
        StartCoroutine("takeCost");
    }

    /*
     * this gets looped over in each players update, so we can even have some sequencing
     * for each towertype override this action 
     */
    public virtual void Action()
    {
        if (!canWork)
            return;
        Debug.Log("Base action taken");
    }

    /*
     * TODO implement player resource pool, check if upkeep can be payed
     * if not disable canwork, stop takeCost
     * only restart on next Resourcegain event from player, maybe make it queueable
     */
    IEnumerator takeCost()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("You have paid your taxes. Good job");
    }
}
