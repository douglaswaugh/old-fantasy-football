namespace AlgorithmFinder.Application.PredictionAccuracyMeasurement
{
    public class Predictions
    {
        private int _correctScoreCount;

        public int CorrectScoreCount
        {
            get { return _correctScoreCount; }
        }

        public void IncrementCorrectScore()
        {
            _correctScoreCount++;
        }
    }
}