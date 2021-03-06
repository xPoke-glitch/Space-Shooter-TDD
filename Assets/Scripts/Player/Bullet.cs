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
    private IObjectPool<Bullet> _IObjectPool;

    public void Destroy()
    {
        _IObjectPool.ReturnToPool(this);
        _currentTimer = 0.0f;
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        _IObjectPool = pool;
    }

    private void Awake()
    {
        _IObjectPool = PlayerBulletPool.Instance;
    }

    private void Update()
    {
        MoveUp();
        TimerToDestroy();
    }

    private void MoveUp()
    {
        this.transform.position += Vector3.up * Time.deltaTime * speed;
    }

    private void TimerToDestroy()
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= DestroyTime)
        {
            Destroy();
        }
    }
}
