namespace AlgorithmFinder.Application.PointsCalculators
{
    public class GoalkeeperPointsCalculator : PointsCalculator
    {
        public decimal CalculatePoints(Player player, DefencePointsMultiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals,
                                       Fixture fixture)
        {
            var defensivePoints = (defenceMultiplier.CleanSheet * 4) + (defenceMultiplier.ConcedeTwoOrThree * -1) + (defenceMultiplier.ConcedeFourOrFive * -2);

            var saves = player.Saves / 3m;

            var bonus = player.Bonus;

            return defensivePoints + saves + bonus;
        }
    }
}