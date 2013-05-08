using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public class FileResultsProvider : ResultsProvider
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

        public Results GetResultsBefore(DateTime before)
        {
            if (_results == null)
            {
                BuildResults();
            }

            return new Results(_results.Where(r => r.MatchDate < before).ToList());
        }

        public Fixtures GetFixturesAfter(DateTime date)
        {
            if (_results == null)
            {
                BuildResults();
            }

            return new Fixtures(_results.Where(r => r.MatchDate >= date).ToList());
        }

        public Fixtures GetFixturesAfter(DateTime date, Team team)
        {
            if (_results == null)
            {
                BuildResults();
            }

            return new Fixtures(GetFixturesAfter(date).Where(r => r.FixtureFor(team)).ToList());
        }

        private void BuildResults()
        {
            _results = new Results(new List<Fixture>());
            using (var reader = _streamer.GetStreamReaderFor(_filePath))
            {
                reader.ReadLine();
                string rawResult;
                while ((rawResult = reader.ReadLine()) != null)
                {
                    _results.Add(_parser.ParseLine(rawResult));
                }
            }
        }
    }
}