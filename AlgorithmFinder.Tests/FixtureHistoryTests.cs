using System.Collections.Generic;
using AlgorithmFinder.Application;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class FixtureHistoryTests
    {
        private FixtureHistory _fixtureHistory;

        [SetUp]
        public void SetUp()
        {
            _fixtureHistory = new FixtureHistory(new List<PlayerFixture>
            {
                NewPlayerFixture(3, 0, 0, 0, 0, 1),
                NewPlayerFixture(4, 0, 1, 0, 0, 1),
                NewPlayerFixture(5, 0, 2, 1, 1),
                NewPlayerFixture(2, 0, 1, 0, 1),
                NewPlayerFixture(3, 1, 0, 2, 0)
            });
        }

        [Test]
        public void SavesShouldBeCalculatedCorrectly()
        {
            Assert.That(_fixtureHistory.Saves, Is.EqualTo(3.4m).Within(0.0001m));
        }

        [Test]
        public void BonusShouldBeCalculatedCorrectly()
        {
            Assert.That(_fixtureHistory.Bonus, Is.EqualTo(0.2m).Within(0.001m));
        }

        [Test]
        public void Goals_should_be_counted_correctly()
        {
            Assert.That(_fixtureHistory.Goals, Is.EqualTo(4));
        }

        [Test]
        public void Yellow_cards_should_be_calculated_correctly()
        {
            Assert.That(_fixtureHistory.YellowCards, Is.EqualTo(0.4m));
        }

        [Test]
        public void Red_cards_should_be_calculated_correctly()
        {
            Assert.That(_fixtureHistory.RedCards, Is.EqualTo(0.4m));
        }

        private PlayerFixture NewPlayerFixture(int saves, int bonus, int goals, int assists, int yellowCards, int redCards = 0)
        {
            return new PlayerFixture(saves, bonus, goals, assists, yellowCards, redCards, 0);
        }
    }
}