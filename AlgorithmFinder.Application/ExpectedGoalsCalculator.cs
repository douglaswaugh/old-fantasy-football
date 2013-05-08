namespace AlgorithmFinder.Application
{
    public interface ExpectedGoalsCalculator
    {
        ExpectedGoals ExpectedGoalsFor(Team team, Fixture fixture);
    }
}