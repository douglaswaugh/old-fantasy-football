using System;
using MathNet.Numerics.Distributions;

namespace AlgorithmFinder.Application
{
    public class ExpectedPointsCalculator
    {
        private readonly ExpectedGoalsCalculator _expectedGoalsCalculator;
        private readonly ProbabilityCalculator _probabilityCalculator;

        public ExpectedPointsCalculator(ExpectedGoalsCalculator expectedGoalsCalculator, ProbabilityCalculator probabilityCalculator)
        {
            _expectedGoalsCalculator = expectedGoalsCalculator;
            _probabilityCalculator = probabilityCalculator;
        }

        public decimal GetPointsFor(Player player, Team team, Fixture fixture)
        {
            var expectedGoals = _expectedGoalsCalculator.ExpectedGoalsFor(fixture);

            var probabilityMatrix = _probabilityCalculator.GetPrediction(expectedGoals);

            var prediction = new Prediction(probabilityMatrix);

            var defencePoints = fixture.HomeTeam.Equals(team) ? prediction.DefencePointsForHomeTeam() : prediction.DefencePointsForAwayTeam();

            /* TODO Refactor above to what's below
            var expectedToConceed = _expectedGoalsCalculator.ExpectedToConceed(team, fixture);

            var defencePoints = _defencePointsCalculator.Calculate(expectedToConceed);*/

            var bonusPoints = player.Bonus;

            var goalPoints = team.GoalsRatioFor(player) * 6m * (fixture.HomeTeam.Equals(team) ? expectedGoals.ExpectedHomeGoals : expectedGoals.ExpectedAwayGoals);

            return defencePoints + bonusPoints + goalPoints;
        }
    }
}