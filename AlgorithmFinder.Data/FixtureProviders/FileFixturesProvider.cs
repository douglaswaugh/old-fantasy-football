using System;
using System.Linq;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data.FixtureProviders
{
    public class FileFixturesProvider : FixturesProvider
    {
        private readonly string _filePath;
        private readonly Streamer _streamer;
        private Results _results;
        private readonly FixtureParser _parser;

        public FileFixturesProvider(Streamer streamer, FixtureParser parser, string filePath)
        {
            _streamer = streamer;
            _parser = parser;
            _filePath = filePath;
        }

        public Fixtures GetFixturesAfter(DateTime date)
        {
            if (_results == null)
            {
                BuildResults();
            }

            return new Fixtures(_results.After(date).ToList());
        }

        public Fixtures GetFixturesAfter(DateTime date, Team team)
        {
            if (_results == null)
            {
                BuildResults();
            }

            return new Fixtures(GetFixturesAfter(date).Where(r => r.HasTeam(team)).ToList());
        }

        private void BuildResults()
        {
            using (var reader = _streamer.GetStreamReaderFor(_filePath))
            {
                _results = new Results(_parser.ParseFixtures(reader).ToList());
            }
        }
    }
}