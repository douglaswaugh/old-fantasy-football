namespace AlgorithmFinder.Application.PointsCalculators
{
    public class DefenderPointsCalculator : PointsCalculator
    {
        public decimal CalculatePoints(Player player, DefencePointsMultiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals, Fixture fixture)
        {
            var defencePoints = (defenceMultiplier.CleanSheet * 4) + (defenceMultiplier.ConcedeTwoOrThree * -1) + (defenceMultiplier.ConcedeFourOrFive * -2);

            var bonusPoints = player.Bonus;

            var goalPoints = team.GoalsRatioFor(player) * 6m * expectedGoals.Team;

            var assistPoints = team.AssistsRatioFor(player) * 3m * expectedGoals.Team;

            return defencePoints + bonusPoints + goalPoints + assistPoints;
        }
    }
}