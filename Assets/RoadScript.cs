using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public static RoadScript instance;
    public List<Transform> points;

    private void Start()
    {
        instance = this;
    }
}
