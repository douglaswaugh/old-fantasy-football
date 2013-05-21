namespace AlgorithmFinder.Application.PointsCalculators
{
    public class ForwardPointsCalculator : PointsCalculator
    {
        public decimal CalculatePoints(Player player, DefencePointsMultiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals,
                                       Fixture fixture)
        {
            var bonusPoints = player.Bonus;

            var goalPoints = team.GoalsRatioFor(player) * 4m * expectedGoals.Team;

            var assistPoints = team.AssistsRatioFor(player) * 3m * expectedGoals.Team;

            var yellowCards = player.YellowCards;

            var redCards = player.RedCards * 3;

            return bonusPoints + goalPoints + assistPoints - yellowCards - redCards;
        }
    }
}