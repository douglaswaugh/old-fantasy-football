using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public interface FixtureParser
    {
        Fixture ParseLine(string rawResult);
    }
}