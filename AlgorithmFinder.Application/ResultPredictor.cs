using AlgorithmFinder.Application.PredictionAccuracyMeasurement;

namespace AlgorithmFinder.Application
{
    public class ResultPredictor
    {
        private readonly ProbabilityCalculator _probabilityCalculator;

        public ResultPredictor(ProbabilityCalculator probabilityCalculator)
        {
            _probabilityCalculator = probabilityCalculator;
        }

        public Predictions GetPredictionResult(Fixtures fixtures, Results expectedGoalsCalculator)
        {
            var predictions = new Predictions();

            foreach (var fixture in fixtures)
            {
                fixture.Predict(expectedGoalsCalculator, _probabilityCalculator);

                if (fixture.PredictionCorrect)
                {
                    predictions.IncrementCorrectScore();
                }
            }

            return predictions;
        }
    }
}