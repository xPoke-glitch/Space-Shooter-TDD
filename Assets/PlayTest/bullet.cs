using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class bullet
{
    [UnityTest]
    public IEnumerator bullet_is_moving_up()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Bullet");
        testObject.AddComponent<Bullet>();

        // Act
        yield return new WaitForSeconds(1.0f);

        // Assert
        Assert.IsTrue(testObject.transform.position.y > 0.0f);
    }

    [UnityTest]
    public IEnumerator bullet_is_destroyed_after_time()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Bullet");
        Bullet bullet = testObject.AddComponent<Bullet>();

        // Act
        yield return new WaitForSeconds(bullet.DestroyTime + 0.1f);

        // Assert
        Assert.IsTrue(null == testObject); // IsNull not correct to use it in this case - Object is not techincally Null, is <Null>
    }
}
