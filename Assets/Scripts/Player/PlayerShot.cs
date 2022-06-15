using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float FireRate { get => fireRate; }

    [SerializeField]
    private float fireRate = 1.0f;

    [SerializeField]
    private GameObject bulletPrefab;

    private IInput _IInputManager;

    private float _fireRateTimer = 0.0f;
    private bool _canShoot = true;

    public void SetInput(IInput input)
    {
        _IInputManager = input;
    }
    public void SetPrefab(GameObject prefab)
    {
        bulletPrefab = prefab;
    }

    private void Awake()
    {
        _IInputManager = InputManager.Instance;
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
        Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
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
