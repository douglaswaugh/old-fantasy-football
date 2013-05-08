using AlgorithmFinder.Application.PredictionAccuracyMeasurement;

namespace AlgorithmFinder.Application
{
    public class ResultPredictor : PredictionListener
    {
        private Predictions _predictions;

        public Predictions GetPredictionResult(Fixtures fixtures, Results results)
        {
            _predictions = new Predictions();

            foreach (var fixture in fixtures)
            {
                fixture.AddPredictionListener(this);
                fixture.Predict(results);
            }

            return _predictions;
        }

        public void AddCorrectPrediction()
        {
            _predictions.IncrementCorrectScore();
        }
    }
}