using System.Collections.Generic;
using System.IO;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public interface FixtureParser
    {
        IEnumerable<Fixture> ParseFixtures(StreamReader reader);
    }
}