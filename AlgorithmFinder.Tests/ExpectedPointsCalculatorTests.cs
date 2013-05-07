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

            var fixtureHistory = new FixtureHistory();

            fixtureHistory.Add(new PlayerFixture(0, 0, 1, 0));
            fixtureHistory.Add(new PlayerFixture(0, 0, 2, 1));

            _wigan.AddPlayer(new Player(514, "Kone", new ForwardPointsCalculator(), fixtureHistory));
        }

        [Test]
        public void Should_calculate_expected_points()
        {
            var expectedGoalsCalculator = Substitute.For<ExpectedGoalsCalculator>();
            
            expectedGoalsCalculator
                .ExpectedGoalsFor(new Fixture(new Team("Wolves"), _wigan))
                .Returns(new ExpectedGoals(1.92m, 2.88m));

            var expectedPointsCalculator = new ExpectedPointsCalculator(expectedGoalsCalculator);

            var fixtureHistory = new FixtureHistory();
            
            fixtureHistory.Add(new PlayerFixture(0, 0, 0, 1));
            fixtureHistory.Add(new PlayerFixture(0, 0, 1, 0));
            fixtureHistory.Add(new PlayerFixture(0, 0, 2, 2));
            fixtureHistory.Add(new PlayerFixture(0, 0, 1, 0));
            fixtureHistory.Add(new PlayerFixture(0, 1, 0, 1));

            var figueroa = new Player(508, "Figueroa", new DefenderPointsCalculator(), fixtureHistory);

            _wigan.AddPlayer(figueroa);

            var expectedPoints = expectedPointsCalculator.GetPointsFor(
                figueroa,
                _wigan, 
                new Fixture(new Team("Wolves"), _wigan));

            Assert.That(expectedPoints, Is.EqualTo(16.8997m).Within(0.0001m));
        }
    }
}