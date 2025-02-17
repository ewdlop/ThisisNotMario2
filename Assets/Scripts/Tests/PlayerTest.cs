using NUnit.Framework;  // Required for testing
using UnityEngine;
using UnityEngine.TestTools;


public class PlayerTest
{ 
    public class Player
    {
        public int Health { get; private set; } = 100;

        public void TakeDamage(int damage)
        {
            Health = Mathf.Max(0, Health - damage);
        }
    }


    private Player player;

    [SetUp] // Runs before each test
    public void Setup()
    {
        player = new Player();
    }

    [Test] // Marks this as a test case
    public void Player_TakesDamage()
    {
        player.TakeDamage(30);
        Assert.AreEqual(70, player.Health, "Health should decrease correctly after taking damage.");
    }

    [Test]
    public void Player_CannotHaveNegativeHealth()
    {
        player.TakeDamage(200);
        Assert.AreEqual(0, player.Health, "Health should not be negative.");
    }
}
