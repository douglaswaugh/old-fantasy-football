using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class FixtureTests
    {
        [Test]
        public void ShouldReturnExpectedPointsForGoalKeeper()
        {
            // fixture that was predicted
            var fixture = new Fixture(new Team("teamA"), new Team("teamB"));
            
            // parameters needed for prediction
            var fixtureHistory = new FixtureHistory();
            fixtureHistory.Add(new PlayerFixture(5, 1, 0));

            var player = new Player(1, "Al Habsi", new StubPointsCalculator(), fixtureHistory);

            var team = new Team("teamE");

            // act
            var prediction = Substitute.For<IPrediction>();
            prediction.DefencePointsForAwayTeam().Returns(0.5m);

            var results = Substitute.For<ExpectedGoalsCalculator>();
            results.ExpectedAwayGoals(null).ReturnsForAnyArgs(2.5m);

            var pointsPrediction = fixture.ExpectedPointsFor(player, team, results, prediction);

            // assert
            Assert.That(pointsPrediction, Is.EqualTo(3.16666).Within(0.00001));
        }
    }

    public class StubPointsCalculator : PointsCalculator
    {
        public decimal CalculatePoints(Player player, Multiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals,
                                       Fixture fixture)
        {
            throw new System.NotImplementedException();
        }
    }

    public class StubProbabilityCalculator : ProbabilityCalculator
    {
        public double[][] GetPrediction(ExpectedGoals expectedGoals)
        {
            var prediction = new double [3][];

            prediction[0] = new double[3] { 0.1, 0.3, 0.2 };
            prediction[1] = new double[3] { 0.2, 0.1, 0.2 };
            prediction[2] = new double[3] { 0.3, 0.1, 0.3 };

            return prediction;
        }
    }
}
