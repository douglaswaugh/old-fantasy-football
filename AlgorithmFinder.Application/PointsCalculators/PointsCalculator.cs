namespace AlgorithmFinder.Application.PointsCalculators
{
    public interface PointsCalculator
    {
        decimal DefencePoints(PoissonDefencePointsMultiplier defenceMultiplier);
        
        decimal GoalPoints(decimal goalsRatio, decimal expectedGoals);
    }
}