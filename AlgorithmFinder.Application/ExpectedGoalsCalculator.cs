namespace AlgorithmFinder.Application
{
    public interface ExpectedGoalsCalculator
    {
        decimal ExpectedHomeGoals(Fixture fixture);

        decimal ExpectedAwayGoals(Fixture fixture);

        ExpectedGoals ExpectedGoalsFor(Fixture fixture);
    }
}