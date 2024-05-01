// Created by David Horvath : dhorvath@student.hive.fi

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourcePool : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField]
    private Dictionary<MaterialObject, float> _resources;

    /*
     * checks if amount can be paid from material
     */
    private bool HasEnough(MaterialObject material, float amount)
    {
        return (_resources.TryGetValue(material, out float value) && value >= amount);
    }

    /*
     * checks if cost can be paid
     */
    private bool HasEnough(Dictionary<MaterialObject, float> costs)
    {
        foreach (KeyValuePair<MaterialObject, float> cost in costs)
        {
            if (!(_resources.TryGetValue(cost.Key, out float value) && value >= cost.Value))
                return false;
        }
        return true;
    }

    /*
     * tries to remove material from player resource
     * return   whether the amount can be paid
     *          and the amount paid
     * out extraneeded 
     *          if it returns false then the extra amount
     *          of material needed otherwise 0
     */
    public (bool, float) TryTakeMaterial(MaterialObject material, float amount, out float extraneeded)
    {
        bool found = _resources.TryGetValue(material, out float value);
        bool canChange = HasEnough(material, amount);
        extraneeded = 0;
        if (canChange)
            _resources[material] -= amount;
        else
            extraneeded = value - amount;
        return (canChange, canChange ? amount : 0);
    }

    /*
     * return   if the full cost can be paid
     *          and what part of the cost can be paid fully (no partial)
     * out extraneeded
     *          if false the extra materials needed
     *          otherwise its the cost
     */
    public (bool, Dictionary<MaterialObject, float>) TryTakeMaterial(Dictionary<MaterialObject, float> costs, out Dictionary<MaterialObject, float> extraneeded)
    {
        extraneeded = new Dictionary<MaterialObject, float>();
        if (HasEnough(costs))
        {
            foreach (KeyValuePair<MaterialObject, float> cost in costs)
                _resources[cost.Key] -= cost.Value;
            return (true, costs);
        }
        else
        {
            Dictionary<MaterialObject, float> canPay = new Dictionary<MaterialObject, float>();
            foreach (KeyValuePair<MaterialObject, float> cost in costs)
            {
                if (_resources.TryGetValue(cost.Key, out float value))
                {
                    extraneeded.Add(cost.Key, cost.Value - value);
                    if (cost.Value - value >= 0)
                        canPay.Add(cost.Key, cost.Value);
                }
                else
                    extraneeded.Add(cost.Key, cost.Value);
            }
            return (false, canPay);
        }
    }

    /*
     * increases the amount of material if found
     * adds it to the dictionary if not
     */
    public bool TryAddMaterial(MaterialObject material, float amount, out float f)
    {
        f = amount;
        if (_resources.TryAdd(material, amount))
            return true;
        _resources[material] += amount;
        return true;
    }
}
