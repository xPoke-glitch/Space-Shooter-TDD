using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class enemy_spawner
{
    private GameObject _enemyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Enemy.prefab");

    [UnityTest]
    public IEnumerator enemies_are_spawned()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Spawner");
        EnemySpawner spawner = testObject.AddComponent<EnemySpawner>();
        spawner.SetPrefab(_enemyPrefab);

        // Act
        yield return new WaitForSeconds(spawner.SpawnRate);

        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        
        // Assert
        Assert.AreEqual(2,enemies.Length);
    }
}