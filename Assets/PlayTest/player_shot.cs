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
        PlayerBulletPool playerBulletPool = testObject.AddComponent<PlayerBulletPool>();
        IInput inputManager = Substitute.For<IInput>();
        playerShot.SetInput(inputManager);
        playerShot.SetPool(playerBulletPool);
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
        Bullet[] bullets = GameObject.FindObjectsOfType<Bullet>();
        if (bullets.Length > 0)
            yield return new WaitForSeconds(bullets[0].DestroyTime);

        GameObject testObject = new GameObject("Test_Player");
        PlayerShot playerShot = testObject.AddComponent<PlayerShot>();
        PlayerBulletPool playerBulletPool = testObject.AddComponent<PlayerBulletPool>();
        IInput inputManager = Substitute.For<IInput>();
        playerShot.SetInput(inputManager);
        playerShot.SetPool(playerBulletPool);
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

        bullets = GameObject.FindObjectsOfType<Bullet>();

        // Assert
        Assert.AreEqual(2, bullets.Length);
    }

    [UnityTest]
    public IEnumerator player_shooting_and_shot_returning_to_pool()
    {
        // Arrange
        Bullet[] bullets = GameObject.FindObjectsOfType<Bullet>();
        if (bullets.Length > 0)
            yield return new WaitForSeconds(bullets[0].DestroyTime);

        GameObject testObject = new GameObject("Test_Player");
        PlayerShot playerShot = testObject.AddComponent<PlayerShot>();
        PlayerBulletPool playerBulletPool = testObject.AddComponent<PlayerBulletPool>();
        IInput inputManager = Substitute.For<IInput>();
        playerShot.SetInput(inputManager);
        playerShot.SetPool(playerBulletPool);
        playerShot.SetPrefab(_bulletPrefab);

        // Act
        inputManager.GetShootPressed().Returns(true);
        yield return new WaitForSeconds(0.1f);
        inputManager.GetShootPressed().Returns(false);

        Bullet bullet = GameObject.FindObjectOfType<Bullet>();

        yield return new WaitForSeconds(bullet.DestroyTime+0.2f);
        bullet = null;

        inputManager.GetShootPressed().Returns(true);
        yield return new WaitForSeconds(0.1f);
        inputManager.GetShootPressed().Returns(false);

        bullet = GameObject.FindObjectOfType<Bullet>();

        // Assert
        Assert.IsTrue(bullet != null);
    }
}
