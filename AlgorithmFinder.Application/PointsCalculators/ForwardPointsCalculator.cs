namespace AlgorithmFinder.Application.PointsCalculators
{
    public class ForwardPointsCalculator : PointsCalculator
    {
        public decimal DefencePoints(PoissonDefencePointsMultiplier defenceMultiplier)
        {
            return 0m;
        }

        public decimal GoalPoints(decimal goalsRatio, decimal expectedGoals)
        {
            return goalsRatio * 4m * expectedGoals;
        }
    }
}