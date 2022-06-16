using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float DestroyTime { get => destroyTime; }

    [SerializeField]
    private float destroyTime = 10.0f;
    [SerializeField]
    private float movementSpeed = 2.0f;

    private float _currentTimer = 0.0f;

    public void Destroy()
    { 
        _currentTimer = 0.0f;
        GameObject.Destroy(gameObject);
    }

    private void Update()
    {
        Move();
        TimerToDestroy();
    }

    private void Move()
    {
        transform.position += Vector3.down * movementSpeed * Time.deltaTime;
    }

    private void TimerToDestroy()
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= DestroyTime)
        {
            Destroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() != null)
        {
            collision.gameObject.GetComponent<Bullet>().Destroy();
            Destroy(gameObject);
        }
        if (collision.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
