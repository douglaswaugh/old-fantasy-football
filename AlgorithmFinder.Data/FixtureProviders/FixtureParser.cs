using System.Collections.Generic;
using System.IO;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data.FixtureProviders
{
    public interface FixtureParser
    {
        IEnumerable<Fixture> ParseFixtures(StreamReader reader);
        
        IEnumerable<Fixture> GetFixtures();
    }
}