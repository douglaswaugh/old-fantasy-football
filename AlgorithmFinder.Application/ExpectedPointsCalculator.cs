using System;

namespace AlgorithmFinder.Application
{
    public class ExpectedPointsCalculator
    {
        private readonly ExpectedGoalsCalculator _expectedGoalsCalculator;

        public ExpectedPointsCalculator(ExpectedGoalsCalculator expectedGoalsCalculator)
        {
            _expectedGoalsCalculator = expectedGoalsCalculator;
        }

        public decimal GetPointsFor(Player player, Fixture fixture)
        {
            var expectedGoals = _expectedGoalsCalculator.ExpectedGoalsFor(player.Team, fixture);

            throw new NotImplementedException();

            /*return player.ExpectedPoints(new PoissonDefencePointsMultiplier(expectedGoals.ForOpponent), player.Team, expectedGoals, fixture);*/
        } 
    }
}