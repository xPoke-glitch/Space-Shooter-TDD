using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float DestroyTime { get => destroyTime; }

    [SerializeField]
    private float destroyTime = 10.0f;
    [SerializeField]
    private float speed = 4.0f;

    private float _currentTimer = 0.0f;

    private void Update()
    {
        MoveUp();
        Destroy();
    }

    private void MoveUp()
    {
        this.transform.position += Vector3.up * Time.deltaTime * speed;
    }

    private void Destroy()
    {
        _currentTimer += Time.deltaTime;
        if(_currentTimer >= DestroyTime)
            Destroy(gameObject);
    }
}
