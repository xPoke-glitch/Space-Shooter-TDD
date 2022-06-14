using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2.0f;

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
        if (InputManager.Instance.IsMoving)
        {
            Move(InputManager.Instance.MoveDirection);
        }
    }
}
