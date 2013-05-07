namespace AlgorithmFinder.Application.PointsCalculators
{
    public interface PointsCalculator
    {
        decimal CalculatePoints(Player player, Multiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals, Fixture fixture);
    }
}