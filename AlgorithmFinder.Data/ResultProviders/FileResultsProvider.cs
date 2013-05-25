using System;
using System.Linq;
using AlgorithmFinder.Application;
using AlgorithmFinder.Data.FixtureProviders;

namespace AlgorithmFinder.Data.ResultProviders
{
    public class FileResultsProvider : ResultsProvider, FixturesProvider
    {
        private readonly Streamer _streamer;
        private readonly FixtureParser _parser;
        private readonly string _filePath;
        private Application.Results _results;

        public FileResultsProvider(Streamer streamer, FixtureParser parser, string filePath)
        {
            _streamer = streamer;
            _parser = parser;
            _filePath = filePath;
        }

        public Application.Results GetResultsBefore(DateTime date)
        {
            if (_results == null)
            {
                BuildResults();
            }

            return new Application.Results(_results.Before(date).ToList());
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
                _results = new Application.Results(_parser.ParseFixtures(reader).ToList());
            }
        }
    }
}