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
                NewPlayerFixture(3, 0, 0, 0),
                NewPlayerFixture(4, 0, 1, 0),
                NewPlayerFixture(5, 0, 2, 1),
                NewPlayerFixture(2, 0, 1, 0),
                NewPlayerFixture(3, 1, 0, 2)
            });
        }

        private static PlayerFixture NewPlayerFixture(int saves, int bonus, int goals, int assists)
        {
            return new PlayerFixture(saves, bonus, goals, assists);
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
    }
}