using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class player_shot
{
    private GameObject _bulletPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Bullet.prefab");

    [UnityTest]
    public IEnumerator player_is_shooting()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Player");
        PlayerShot playerShot = testObject.AddComponent<PlayerShot>();
        IInput inputManager = Substitute.For<IInput>();
        playerShot.SetInput(inputManager);
        playerShot.SetPrefab(_bulletPrefab);

        // Act
        inputManager.GetShootPressed().Returns(true);
        yield return new WaitForSeconds(0.1f);
        inputManager.GetShootPressed().Returns(false);

        Bullet bullet = GameObject.FindObjectOfType<Bullet>();

        yield return new WaitForSeconds(0.3f);
        // Assert
        Assert.IsTrue(bullet != null);
    }

    [UnityTest]
    public IEnumerator player_is_shooting_at_correct_fire_rate()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Player");
        PlayerShot playerShot = testObject.AddComponent<PlayerShot>();
        IInput inputManager = Substitute.For<IInput>();
        playerShot.SetInput(inputManager);
        playerShot.SetPrefab(_bulletPrefab);

        // Act
        inputManager.GetShootPressed().Returns(true);
        yield return new WaitForSeconds(0.1f);
        inputManager.GetShootPressed().Returns(false);

        inputManager.GetShootPressed().Returns(true);
        yield return new WaitForSeconds(0.1f);
        inputManager.GetShootPressed().Returns(false);

        yield return new WaitForSeconds(playerShot.FireRate);

        inputManager.GetShootPressed().Returns(true);
        yield return new WaitForSeconds(0.1f);
        inputManager.GetShootPressed().Returns(false);

        Bullet[] bullets = GameObject.FindObjectsOfType<Bullet>();

        // Assert
        Assert.AreEqual(2, bullets.Length);
    }
}
