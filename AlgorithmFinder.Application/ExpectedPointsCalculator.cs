namespace AlgorithmFinder.Application
{
    public class ExpectedPointsCalculator
    {
        private readonly ExpectedGoalsCalculator _expectedGoalsCalculator;

        public ExpectedPointsCalculator(ExpectedGoalsCalculator expectedGoalsCalculator)
        {
            _expectedGoalsCalculator = expectedGoalsCalculator;
        }

        public decimal GetPointsFor(Player player, Team team, Fixture fixture)
        {
            var expectedGoals = _expectedGoalsCalculator.ExpectedGoalsFor(fixture);

            var defenceMultiplierCalculator = new PoissonDefencePointsMultiplier();

            var defenceMultiplier = defenceMultiplierCalculator.Calculate(fixture.HomeTeam.Equals(team) ? expectedGoals.Away : expectedGoals.Home);

            return player.ExpectedPoints(defenceMultiplier, team, expectedGoals, fixture);
        }
    }
}