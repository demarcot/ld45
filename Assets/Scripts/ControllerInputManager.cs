using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputManager : IInputManager
{
    public Vector2 GetDirection()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}