using System;

namespace AlgorithmFinder.Application.PredictionAccuracyMeasurement
{
    public class PredictionMeasurer
    {
        private readonly ResultsProvider _fileResultsProvider;
        private readonly ResultPredictor _resultPredictor;

        public PredictionMeasurer(ResultsProvider fileResultsProvider, ResultPredictor resultPredictor)
        {
            _fileResultsProvider = fileResultsProvider;
            _resultPredictor = resultPredictor;
        }

        public Predictions MeasureAccuracy(DateTime predictAfter)
        {
            var resultsForAccuracy = _fileResultsProvider.GetResultsBefore(predictAfter);
            var fixturesForAccuracyCheck = _fileResultsProvider.GetFixturesAfter(predictAfter);
            return _resultPredictor.GetPredictionResult(fixturesForAccuracyCheck, resultsForAccuracy);
        }
    }
}