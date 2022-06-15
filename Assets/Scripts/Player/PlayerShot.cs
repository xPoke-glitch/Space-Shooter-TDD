using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float FireRate { get => fireRate; }

    [SerializeField]
    private float fireRate = 1.0f;


    private IInput _IInputManager;
    private IObjectPool<Bullet> _IObjectPool;

    private GameObject _bulletPrefab;
    private float _fireRateTimer = 0.0f;
    private bool _canShoot = true;

    public void SetInput(IInput input)
    {
        _IInputManager = input;
    }
    public void SetPrefab(GameObject prefab)
    {
        _bulletPrefab = prefab;
        _IObjectPool.SetPrefab(_bulletPrefab.GetComponent<Bullet>());
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        _IObjectPool = pool;
    }

    private void Awake()
    {
        _IInputManager = InputManager.Instance;
        _IObjectPool = PlayerBulletPool.Instance;
    }

    private void Update()
    {
        if (_IInputManager.GetShootPressed())
        {
            Shot();
        }
        FireRateCheck();
    }

    private void Shot()
    {
        if (!_canShoot)
            return;

        var shot = _IObjectPool.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);

        _canShoot = false;
    }

    private void FireRateCheck()
    {
        if (_canShoot)
            return;
        _fireRateTimer += Time.deltaTime;
        if(_fireRateTimer > fireRate)
        {
            _canShoot = true;
            _fireRateTimer = 0.0f;
        }
    }
}
