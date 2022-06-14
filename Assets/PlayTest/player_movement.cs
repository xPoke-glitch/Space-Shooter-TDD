using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class player_movement
{
    [UnityTest]
    public IEnumerator player_move_left()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Player");
        PlayerMovement playerMovement = testObject.AddComponent<PlayerMovement>();

        // Act
        playerMovement.Move(Vector2.left);
        
        // Assert
        yield return new WaitForSeconds(0.3f);
        Assert.IsTrue(testObject.transform.position.x < 0.0f);
    }

    [UnityTest]
    public IEnumerator player_move_right()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Player");
        PlayerMovement playerMovement = testObject.AddComponent<PlayerMovement>();

        // Act
        playerMovement.Move(Vector2.right);

        // Assert
        yield return new WaitForSeconds(0.3f);
        Assert.IsTrue(testObject.transform.position.x > 0.0f);
    }

    [UnityTest]
    public IEnumerator player_not_move_up_or_down()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Player");
        PlayerMovement playerMovement = testObject.AddComponent<PlayerMovement>();

        // Act
        playerMovement.Move(Vector2.up);
        playerMovement.Move(Vector2.down);
        // Assert
        yield return new WaitForSeconds(0.3f);
        Assert.AreEqual(0.0f, testObject.transform.position.x);
    }
}
