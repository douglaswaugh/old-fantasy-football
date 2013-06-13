namespace AlgorithmFinder.Application.PointsCalculators
{
    public class MidfielderPointsCalculator : PointsCalculator
    {
        public decimal DefencePoints(PoissonDefencePointsMultiplier defenceMultiplier)
        {
            return  defenceMultiplier.CleanSheet;
        }

        public decimal GoalPoints(decimal goalsRatio, decimal expectedGoals)
        {
            return goalsRatio * 5m * expectedGoals;
        }
    }
}