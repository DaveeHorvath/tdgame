using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[DefaultExecutionOrder(100)]
public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    int current;

    void Start()
    {
        current = 0;
        transform.position = RoadScript.instance.points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * (RoadScript.instance.points[current].position - transform.position).normalized);
        if ((transform.position - RoadScript.instance.points[current].position).magnitude < 0.0001f)
            current++;
        if (current == RoadScript.instance.points.Count)
        {
            moveSpeed = 0;
            current = 0;
        }
    }
}
