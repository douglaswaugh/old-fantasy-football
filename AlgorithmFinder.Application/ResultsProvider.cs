namespace AlgorithmFinder.Application
{
    public interface ResultsProvider
    {
        Results GetResults();
        Fixture GetFixture();
        Result GetComparisonResult();
        Fixtures GetFixtures();
        Score GetScore(Fixture fixture);
    }
}