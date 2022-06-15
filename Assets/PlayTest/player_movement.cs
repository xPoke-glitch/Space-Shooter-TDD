using System.Collections;
using System.Collections.Generic;
using NSubstitute;
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
        IInput inputManager = Substitute.For<IInput>();
        playerMovement.SetInput(inputManager);

        // Act
        inputManager.MoveDirection.Returns(Vector2.left);
        inputManager.IsMoving.Returns(true);   

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
        IInput inputManager = Substitute.For<IInput>();
        playerMovement.SetInput(inputManager);

        // Act
        inputManager.MoveDirection.Returns(Vector2.right);
        inputManager.IsMoving.Returns(true);

        // Assert
        yield return new WaitForSeconds(0.3f);
        Assert.IsTrue(testObject.transform.position.x > 0.0f);
    }

    [UnityTest]
    public IEnumerator player_do_not_move_up_or_down()
    {
        // Arrange
        GameObject testObject = new GameObject("Test_Player");
        PlayerMovement playerMovement = testObject.AddComponent<PlayerMovement>();
        IInput inputManager = Substitute.For<IInput>();
        playerMovement.SetInput(inputManager);

        // Act
        inputManager.MoveDirection.Returns(Vector2.up);
        inputManager.IsMoving.Returns(true);        

        yield return new WaitForSeconds(0.3f);

        inputManager.MoveDirection.Returns(Vector2.down);
        inputManager.IsMoving.Returns(true);

        // Assert
        yield return new WaitForSeconds(0.3f);
        Assert.AreEqual(0.0f, testObject.transform.position.x);
    }
}
