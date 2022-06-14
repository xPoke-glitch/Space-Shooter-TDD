using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : Singleton<InputManager>
{
    public bool IsMoving { get; private set; }
    public Vector2 MoveDirection { get; private set; }

    public void MovePressed(InputAction.CallbackContext context)
    { 
        if (context.performed)
        {
            IsMoving = true;
            MoveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            IsMoving = false;
            MoveDirection = context.ReadValue<Vector2>();
        }
    }

    // for any of the below 'Get' methods, if we're getting it then we're also using it,
    // which means we should set it to false so that it can't be used again until actually
    // pressed again. (GetKeyDown Behaviour)

    
}
