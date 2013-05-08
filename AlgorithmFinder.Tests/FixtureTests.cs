using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;

namespace AlgorithmFinder.Tests
{
    public class StubPointsCalculator : PointsCalculator
    {
        public decimal CalculatePoints(Player player, Multiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals,
                                       Fixture fixture)
        {
            throw new System.NotImplementedException();
        }
    }

    public class StubProbabilityCalculator : ProbabilityCalculator
    {
        public double[][] GetPrediction(ExpectedGoals expectedGoals)
        {
            var prediction = new double [3][];

            prediction[0] = new[] { 0.1, 0.3, 0.2 };
            prediction[1] = new[] { 0.2, 0.1, 0.2 };
            prediction[2] = new[] { 0.3, 0.1, 0.3 };

            return prediction;
        }
    }
}
