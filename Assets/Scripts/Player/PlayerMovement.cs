using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2.0f;

    private IInput _IInputManager;

    private void Awake() // this should be constructor (Constructor Dependecy Injection)
    {
        _IInputManager = InputManager.Instance;
    }

    public void SetInput(IInput inputManager) // this should be constructor (Constructor Dependecy Injection)
    {
        _IInputManager = inputManager;
    }

    public void Move(Vector2 direction)
    {
        if (direction.Equals(Vector2.left))
        {
            transform.position += Time.deltaTime * Vector3.left * movementSpeed;
        }
        else if (direction.Equals(Vector2.right))
        {
            transform.position += Time.deltaTime * Vector3.right * movementSpeed;
        }
    }

    private void Update()
    {
        if (_IInputManager.IsMoving)
        {
            Move(_IInputManager.MoveDirection);
        }
    }
}
