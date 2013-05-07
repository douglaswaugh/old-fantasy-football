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

            fixtureHistory.Add(new PlayerFixture(0, 0, 1));
            fixtureHistory.Add(new PlayerFixture(0, 0, 2));

            _wigan.AddPlayer(new Player(514, "Kone", new ForwardPointsCalculator(), fixtureHistory));
        }

        [Test]
        public void Should_calculate_expected_points()
        {
            var expectedGoalsCalculator = Substitute.For<ExpectedGoalsCalculator>();
            
            expectedGoalsCalculator
                .ExpectedGoalsFor(new Fixture(new Team("Wolves"), _wigan))
                .Returns(new ExpectedGoals(1.92m, 2.88m));

            var probabilityCalculator = Substitute.For<ProbabilityCalculator>();
            probabilityCalculator
                .GetPrediction(null)
                .ReturnsForAnyArgs(new[] 
                { 
                    new[] {0.008229747, 0.023701672, 0.034130407, 0.032765191, 0.023590937, 0.01358838 },
                    new[] {0.015801114, 0.045507209, 0.065530381, 0.062909166, 0.0452946  , 0.026089689 },
                    new[] {0.01516907,  0.043686921, 0.062909166, 0.060392799, 0.043482816, 0.025046102 },
                    new[] {0.009708205, 0.027959629, 0.040261866, 0.038651392, 0.027829002, 0.016029505 },
                    new[] {0.004659938, 0.013420622, 0.019325696, 0.018552668, 0.013357921, 0.007694162 },
                    new[] {0.001789416, 0.005153519, 0.007421067, 0.007124225, 0.005129442, 0.002954558 }
                });

            var expectedPointsCalculator = new ExpectedPointsCalculator(expectedGoalsCalculator);

            var fixtureHistory = new FixtureHistory();
            
            fixtureHistory.Add(new PlayerFixture(0, 0, 0));
            fixtureHistory.Add(new PlayerFixture(0, 0, 1));
            fixtureHistory.Add(new PlayerFixture(0, 0, 2));
            fixtureHistory.Add(new PlayerFixture(0, 0, 1));
            fixtureHistory.Add(new PlayerFixture(0, 1, 0));

            var figueroa = new Player(508, "Figueroa", new DefenderPointsCalculator(), fixtureHistory);

            _wigan.AddPlayer(figueroa);

            var expectedPoints = expectedPointsCalculator.GetPointsFor(
                figueroa,
                _wigan, 
                new Fixture(new Team("Wolves"), _wigan));

            Assert.That(expectedPoints, Is.EqualTo(9.9877m).Within(0.0001m));
        }
    }
}