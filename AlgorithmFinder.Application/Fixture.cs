namespace AlgorithmFinder.Application
{
    public class Fixture
    {
        private readonly Team _homeTeam;
        private readonly Team _awayTeam;
        private readonly Score _score;

        public Fixture(Team homeTeam, Team awayTeam)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
        }

        public Fixture(Team homeTeam, Team awayTeam, Score score)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _score = score;
        }

        public Team HomeTeam
        {
            get { return _homeTeam; }
        }

        public Team AwayTeam
        {
            get { return _awayTeam; }
        }

        public void PredictScore(Prediction prediction, IPoissonMatrix poissonMatrix)
        {
            if (poissonMatrix.MostLikelyScore().Equals(_score))
            {
                prediction.IncrementCorrectScore();
            }
        }
    }
}