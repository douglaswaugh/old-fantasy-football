namespace AlgorithmFinder.Application.PointsCalculators
{
    public class GoalkeeperPointsCalculator : PointsCalculator
    {
        public decimal DefencePoints(PoissonDefencePointsMultiplier defenceMultiplier)
        {
            return (defenceMultiplier.CleanSheet * 4) + (defenceMultiplier.ConcedeTwoOrThree * -1) + (defenceMultiplier.ConcedeFourOrFive * -2);
        }

        public decimal GoalPoints(decimal goalsRatio, decimal expectedGoals)
        {
            return goalsRatio *6m *expectedGoals;
        }
    }
}