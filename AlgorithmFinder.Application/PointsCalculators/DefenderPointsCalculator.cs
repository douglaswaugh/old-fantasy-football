namespace AlgorithmFinder.Application.PointsCalculators
{
    public class DefenderPointsCalculator : PointsCalculator
    {
        public decimal CalculatePoints(Player player, Multiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals, Fixture fixture)
        {
            var defencePoints = (defenceMultiplier.CleanSheet * 4) + (defenceMultiplier.ConcedeTwoOrThree * -1) + (defenceMultiplier.ConcedeFourOrFive * -2);

            var bonusPoints = player.Bonus;

            var goalPoints = team.GoalsRatioFor(player) * 6m * (fixture.HomeTeam.Equals(team) ? expectedGoals.Home : expectedGoals.Away);

            var assistPoints = team.AssistsRatioFor(player) * 3m * (fixture.HomeTeam.Equals(team) ? expectedGoals.Home : expectedGoals.Away);

            return defencePoints + bonusPoints + goalPoints + assistPoints;
        }
    }
}