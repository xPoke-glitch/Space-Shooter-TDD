using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class enemy
{
    [UnityTest]
    public IEnumerator enemy_is_moving_down()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Enemy");
        Enemy enemy = testObject.AddComponent<Enemy>();

        // Act
        yield return new WaitForSeconds(0.3f);

        // Assert
        Assert.IsTrue(testObject.transform.position.y < 0);
    }

    [UnityTest]
    public IEnumerator enemy_and_bullet_destroyed_after_bullet_hit()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Enemy");
        testObject.transform.position = new Vector3(0, 4.5f, 0);
        BoxCollider2D collider = testObject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(1.0f, 1.0f);
        collider.isTrigger = true;
        Rigidbody2D rigidbody2D = testObject.AddComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;

        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        Enemy enemy = testObject.AddComponent<Enemy>();

        GameObject testObjectBullet = new GameObject("Test_Bullet");
        testObjectBullet.AddComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        GameObject testPool = new GameObject("Test_Pool");
        PlayerBulletPool playerBulletPool = testPool.AddComponent<PlayerBulletPool>();
        Bullet bullet = testObjectBullet.AddComponent<Bullet>();
        bullet.SetPool(playerBulletPool);

        // Act
        yield return new WaitForSeconds(5.0f);

        // Assert
        Assert.IsTrue(testObject == null && bullet.gameObject.activeSelf == false);
    }

    [UnityTest]
    public IEnumerator enemy_is_destroyed_after_time()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Enemy");
        Enemy enemy = testObject.AddComponent<Enemy>();

        // Act
        yield return new WaitForSeconds(enemy.DestroyTime+0.1f);

        // Assert
        Assert.IsTrue(testObject == null);
    }

    [UnityTest]
    public IEnumerator enemy_kill_player()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Enemy");
        testObject.transform.position = new Vector3(0, 4.0f, 0);
        Enemy enemy = testObject.AddComponent<Enemy>();
        BoxCollider2D collider = testObject.GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
        Rigidbody2D rigidbody2D = testObject.GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;

        GameObject playerTestObject = new GameObject("Test_Player");
        Player player = playerTestObject.AddComponent<Player>();
        BoxCollider2D playerCollider = playerTestObject.AddComponent<BoxCollider2D>();
        playerCollider.size = new Vector2(1.0f, 1.0f);

        // Act
        yield return new WaitForSeconds(5.0f);

        // Assert
        Assert.IsTrue(playerTestObject == null);
    }
}
