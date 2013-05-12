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

            return player.ExpectedPoints(new PoissonDefencePointsMultiplier(expectedGoals.Opponent), player.Team, expectedGoals, fixture);
        } 
    }
}