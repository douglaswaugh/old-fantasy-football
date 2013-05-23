using System;

namespace AlgorithmFinder.Application.PredictionAccuracyMeasurement
{
    public class PredictionMeasurer
    {
        private readonly ResultsProvider _resultsProvider;
        private readonly FixturesProvider _fixturesProvider;
        private readonly ResultPredictor _resultPredictor;

        public PredictionMeasurer(ResultsProvider resultsProvider, FixturesProvider fixturesProvider, ResultPredictor resultPredictor)
        {
            _resultsProvider = resultsProvider;
            _fixturesProvider = fixturesProvider;
            _resultPredictor = resultPredictor;
        }

        public Predictions MeasureAccuracy(DateTime predictAfter)
        {
            var resultsForAccuracy = _resultsProvider.GetResultsBefore(predictAfter);
            var fixturesForAccuracyCheck = _fixturesProvider.GetFixturesAfter(predictAfter);
            return _resultPredictor.GetPredictionResult(fixturesForAccuracyCheck, resultsForAccuracy);
        }
    }
}