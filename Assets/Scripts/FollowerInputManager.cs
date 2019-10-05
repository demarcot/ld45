using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerInputManager : IInputManager
{
    private Vector2 currentDirection;
    private float lastUpdate = Time.time;

    public Vector2 GetDirection()
    {
        if (Time.time - lastUpdate > 0.5)
        {
            currentDirection = new Vector2(Random.Range(-1.0f, 1), Random.Range(-1.0f, 1)).normalized;
            lastUpdate = Time.time;
        }
        return currentDirection;
    }
}
