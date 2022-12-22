using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        FootballTeam team;
        FootballPlayer player;
        string teamName = "real madrid";
        int teamCapacity = 15;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("ronaldo", 7, "Forward");
            team = new FootballTeam(teamName, teamCapacity);
        }

        [Test]
        public void TestConstructor()
        {
            var actualName = team.Name;
            Assert.AreEqual(teamName, actualName);
            Assert.AreEqual(teamCapacity, team.Capacity);
            Assert.AreEqual(0, team.Players.Count);
        }

        [TestCase("")]
        [TestCase(null)]
        public void Test_Name_ShouldThrow(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(name, teamCapacity);
            });
        }

        [TestCase(14)]
        [TestCase(0)]
        public void Test_Capacity_ShouldThrow(int cap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(teamName, cap);
            });
        }

        [Test]
        public void AddPlayer_Should_Throw()
        {
            for (int i = 0; i < 15; i++)
            {
                team.AddNewPlayer(player);
            }

            Assert.AreEqual("No more positions available!", team.AddNewPlayer(player));
        }
        [Test]
        public void AddPlayer_Should_Work()
        {
            Assert.AreEqual($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}", team.AddNewPlayer(player));
            Assert.AreEqual(1, team.Players.Count);
        }
        [Test]
        public void PickPlayer_Should_Work()
        {
            team.AddNewPlayer(player);
            Assert.AreEqual(player, team.PickPlayer(player.Name));
        }
        [Test]
        public void PlayerScore_Should_Work()
        {
            team.AddNewPlayer(player);
            player = new FootballPlayer(player.Name, player.PlayerNumber, player.Position);
            player.Score();

            Assert.AreEqual($"{player.Name} scored and now has {player.ScoredGoals} for this season!", team.PlayerScore(player.PlayerNumber));
        }
    }
}