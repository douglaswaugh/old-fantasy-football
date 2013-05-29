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

            return _results.Before(date);
        }

        private void BuildResults()
        {
            _results = new Results(_parser.GetFixtures().ToList());
        }
    }
}