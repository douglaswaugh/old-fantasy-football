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

            var defencePoints = (defenceMultiplier.CleanSheet * 4) + (defenceMultiplier.ConcedeTwoOrThree * -1) + (defenceMultiplier.ConcedeFourOrFive * -2);

            var bonusPoints = player.Bonus;

            var goalPoints = team.GoalsRatioFor(player) * 6m * (fixture.HomeTeam.Equals(team) ? expectedGoals.Home : expectedGoals.Away);

            return defencePoints + bonusPoints + goalPoints;
        }
    }
}