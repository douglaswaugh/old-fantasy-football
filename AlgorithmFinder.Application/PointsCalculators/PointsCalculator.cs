namespace AlgorithmFinder.Application.PointsCalculators
{
    public interface PointsCalculator
    {
        decimal CalculatePoints(Player player, DefencePointsMultiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals, Fixture fixture);
    }
}