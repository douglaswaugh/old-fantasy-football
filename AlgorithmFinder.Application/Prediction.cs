namespace AlgorithmFinder.Application
{
    public class Prediction
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