using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput 
{
    public bool IsMoving { get; }
    public Vector2 MoveDirection { get; }
}
