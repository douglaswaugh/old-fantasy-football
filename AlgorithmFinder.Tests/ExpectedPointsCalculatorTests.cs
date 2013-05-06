using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class ExpectedPointsCalculatorTests
    {
        [Test]
        public void Should_calculate_expected_points()
        {
            var expectedGoalsCalculator = Substitute.For<ExpectedGoalsCalculator>();
            expectedGoalsCalculator
                .ExpectedGoalsFor(new Fixture(new Team(20), new Team(19)))
                .Returns(new ExpectedGoals(3m, 2m));

            var probabilityCalculator = Substitute.For<ProbabilityCalculator>();

            var expectedPointsCalculator = new ExpectedPointsCalculator(expectedGoalsCalculator, probabilityCalculator);

            expectedPointsCalculator.GetPointsFor(new Player(508, "Figueroa", new DefenderPointsCalculator()),
                                                  new Team(20), new Fixture(new Team(20), new Team(19)));

            expectedGoalsCalculator
                .Received(1)
                .ExpectedGoalsFor(new Fixture(new Team(20), new Team(19)));
        }
    }
}