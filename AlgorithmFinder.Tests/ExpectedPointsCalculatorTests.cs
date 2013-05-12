using System.Collections.Generic;
using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class ExpectedPointsCalculatorTests
    {
        private Team _wigan;

        [SetUp]
        public void SetUp()
        {
            _wigan = new Team("Wigan");

            var fixtures = new List<PlayerFixture>
                {
                    new PlayerFixture(0, 0, 1, 0), 
                    new PlayerFixture(0, 0, 2, 1)
                };

            _wigan.AddPlayer(new Player(514, "Kone", new ForwardPointsCalculator(), new FixtureHistory(fixtures), _wigan));
        }

        [Test]
        public void Should_calculate_expected_points()
        {
            var expectedGoalsCalculator = Substitute.For<ExpectedGoalsCalculator>();
            
            expectedGoalsCalculator
                .ExpectedGoalsFor(_wigan, new Fixture(new Team("Wolves"), _wigan))
                .Returns(new ExpectedGoals(2.88m, 1.92m));

            var expectedPointsCalculator = new ExpectedPointsCalculator(expectedGoalsCalculator);

            var fixtures = new List<PlayerFixture>();
            
            fixtures.Add(new PlayerFixture(0, 0, 0, 1));
            fixtures.Add(new PlayerFixture(0, 0, 1, 0));
            fixtures.Add(new PlayerFixture(0, 0, 2, 2));
            fixtures.Add(new PlayerFixture(0, 0, 1, 0));
            fixtures.Add(new PlayerFixture(0, 1, 0, 1));

            var figueroa = new Player(508, "Figueroa", new DefenderPointsCalculator(), new FixtureHistory(fixtures), _wigan);

            _wigan.AddPlayer(figueroa);

            var expectedPoints = expectedPointsCalculator.GetPointsFor(
                figueroa, 
                new Fixture(new Team("Wolves"), _wigan));

            Assert.That(expectedPoints, Is.EqualTo(16.8997m).Within(0.0001m));
        }
    }
}