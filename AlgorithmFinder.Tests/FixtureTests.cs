using AlgorithmFinder.Application;
using Moq;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class FixtureTests
    {
        [Test]
        public void CalculatesMostLikelyScore()
        {
            var homeTeam = new Team("liverpool");
            var awayTeam = new Team("reading");
            var fixture = new Fixture(homeTeam, awayTeam);

            var prediction = new Prediction();

            fixture.PredictScore(prediction, new StubPoissonMatrix());

            Assert.That(prediction.CorrectScoreCount, Is.EqualTo(0));
        }
    }

    public class StubPoissonMatrix : IPoissonMatrix
    {
        public Score MostLikelyScore()
        {
            return new Score(1, 2);
        }
    }

    public class StubResults : IResults
    {
        public double ExpectedHomeGoals(Team homeTeam, Team awayTeam)
        {
            return 1.92;
        }

        public double ExpectedAwayGoals(Team homeTeam, Team awayTeam)
        {
            return 2.88;
        }
    }
}
