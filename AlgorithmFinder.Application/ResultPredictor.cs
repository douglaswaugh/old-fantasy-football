namespace AlgorithmFinder.Application
{
    public class ResultPredictor
    {
        private readonly ResultsProvider _resultsProvider;

        public ResultPredictor(ResultsProvider resultsProvider)
        {
            _resultsProvider = resultsProvider;
        }

        public Prediction GetPredictionResult()
        {
            var results = _resultsProvider.GetResults();

            var fixtures = _resultsProvider.GetFixtures();

            var prediction = new Prediction();

            fixtures.GetPrediction(results, prediction);

            return prediction;
        }
    }
}