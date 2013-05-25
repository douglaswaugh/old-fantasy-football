using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public class FileResultsProvider : ResultsProvider, FixturesProvider
    {
        private readonly Streamer _streamer;
        private readonly FixtureParser _parser;
        private readonly string _filePath;
        private Results _results;

        public FileResultsProvider(Streamer streamer, FixtureParser parser, string filePath)
        {
            _streamer = streamer;
            _parser = parser;
            _filePath = filePath;
        }

        public Results GetResultsBefore(DateTime date)
        {
            if (_results == null)
            {
                BuildResults();
            }

            return new Results(_results.Before(date).ToList());
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