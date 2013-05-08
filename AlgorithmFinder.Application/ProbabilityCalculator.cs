namespace AlgorithmFinder.Application
{
    public interface ProbabilityCalculator
    {
        double[][] GetPrediction(ExpectedGoals expectedGoals);
    }
}