using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgorithmFinder.Application;
using Newtonsoft.Json;

namespace AlgorithmFinder.Data.FixtureProviders
{
    public class JsonFileFixtureParser : FixtureParser
    {
        private readonly Streamer _streamer;
        private readonly string _filePath;

        public JsonFileFixtureParser(Streamer streamer, string filePath)
        {
            _streamer = streamer;
            _filePath = filePath;
        }

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

        public IEnumerable<Fixture> GetFixtures()
        {
            using (var reader = _streamer.GetStreamReaderFor(_filePath))
            {
                return ParseFixtures(reader).ToList();
            }
        }
    }
}