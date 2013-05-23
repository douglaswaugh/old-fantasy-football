using System.Collections.Generic;
using System.IO;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public interface FixtureParser
    {
        Fixture ParseFixtre(string rawResult);

        IEnumerable<string> ParseFixtures(StreamReader reader);
    }
}