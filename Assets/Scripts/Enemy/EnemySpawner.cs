using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnRate { get=>spawnRate;}

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float spawnRate = 2.5f;
    [SerializeField]
    private Vector2Int xRange = new Vector2Int(-8,8);

    private float _spawnRateTimer = 0.0f;

    public void SetPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        ContinueSpawn();
    }

    private void ContinueSpawn()
    {
        _spawnRateTimer += Time.deltaTime;
        if(_spawnRateTimer >= spawnRate)
        {
            Spawn();
            _spawnRateTimer = 0.0f;
        }
    }

    private void Spawn()
    {
        int randomX = Random.Range(xRange.x, xRange.y);

        Instantiate(prefab, new Vector3(randomX, 6.0f, 0), Quaternion.identity);
    }
}
