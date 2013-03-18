using System.Collections.Generic;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public class FileResultsProvider : ResultsProvider
    {
        private readonly IStreamer _streamer;
        private readonly ExcelLineResultParser _parser;
        private Results _results;

        public FileResultsProvider(IStreamer streamer, ExcelLineResultParser parser)
        {
            _streamer = streamer;
            _parser = parser;
        }

        public Results GetResults()
        {
            if (_results == null)
            {
                BuildResults();
            }

            return _results;
        }

        private void BuildResults()
        {
            _results = new Results(new List<Result>());
            using (var reader = _streamer.GetStream())
            {
                var header = reader.ReadLine();
                string rawResult;
                while ((rawResult = reader.ReadLine()) != null)
                {
                    _results.Add(_parser.ParseLine(rawResult));
                }
            }
        }

        public Fixture GetFixture()
        {
            throw new System.NotImplementedException();
        }

        public Result GetComparisonResult()
        {
            throw new System.NotImplementedException();
        }

        public Fixtures GetFixtures()
        {
            throw new System.NotImplementedException();
        }

        public Score GetScore(Fixture fixture)
        {
            throw new System.NotImplementedException();
        }
    }
}