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
                new PlayerFixture(3, 0, 0),
                new PlayerFixture(4, 0, 1),
                new PlayerFixture(5, 0, 2),
                new PlayerFixture(2, 0, 1),
                new PlayerFixture(3, 1, 0)
            });
        }

        [Test]
        public void SavesShouldBeCalculatedCorrectly()
        {
            Assert.That(_fixtureHistory.Saves, Is.EqualTo(1.1333m).Within(0.0001m));
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