using System;
using System.Linq;
using AlgorithmFinder.Application;
using AlgorithmFinder.Data.FixtureProviders;

namespace AlgorithmFinder.Data.ResultProviders
{
    public class FileResultsProvider : ResultsProvider
    {
        private readonly FixtureParser _parser;
        private Results _results;

        public FileResultsProvider(FixtureParser parser)
        {
            _parser = parser;
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
            _results = new Results(_parser.GetFixtures().ToList());
        }
    }
}