using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World_Settings/MovementSettings", menuName = "Movement Settings", order = 51)]
public class MovementSettings : ScriptableObject
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isAi;

    public float GetSpeed()
    {
        return speed;
    }

    public bool GetIsAi()
    {
        return isAi;
    }

    public IInputManager BuildInputManager()
    {
        if (isAi)
        {
            return new FollowerInputManager();
        }
        else
        {
            return new ControllerInputManager();
        }
    }
}
