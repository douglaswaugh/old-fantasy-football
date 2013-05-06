namespace AlgorithmFinder.Application
{
    public interface ProbabilityCalculator
    {
        /*Score MostLikelyScore();
        Score MostLikelyScoreFor(Fixture fixture, ExpectedGoalsCalculator results);*/
        double[][] GetPrediction(ExpectedGoals expectedGoals);
    }
}