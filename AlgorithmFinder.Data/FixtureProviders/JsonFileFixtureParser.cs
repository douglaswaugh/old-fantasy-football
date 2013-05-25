using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgorithmFinder.Application;
using Newtonsoft.Json;

namespace AlgorithmFinder.Data.FixtureProviders
{
    public class JsonFileFixtureParser : FixtureParser
    {
        public IEnumerable<Fixture> ParseFixtures(StreamReader reader)
        {
            var fixtures = JsonConvert.DeserializeObject<FplFixtures>(reader.ReadToEnd());

            return fixtures.Fixtures.Select(f => new Fixture
            (
                new Team(f.HomeTeam.Name),
                new Team(f.AwayTeam.Name),
                f.Date,
                new Score(f.HomeGoals, f.AwayGoals))
            );
        }
    }
}