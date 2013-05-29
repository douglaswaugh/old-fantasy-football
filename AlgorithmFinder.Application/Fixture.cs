using System;

namespace AlgorithmFinder.Application
{
    public class Fixture
    {
        private readonly DateTime _matchDate;
        private readonly Team _homeTeam;
        private readonly Team _awayTeam;
        private readonly Score _score;
        private Score _predictedScore;
        private PredictionListener _predictionListener;

        public Fixture(Team homeTeam, Team awayTeam, DateTime matchDate, Score score)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _matchDate = matchDate;
            _score = score;
        }

        public Fixture(Team homeTeam, Team awayTeam, DateTime matchDate)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _matchDate = matchDate;
        }

        public Team HomeTeam
        {
            get { return _homeTeam; }
        }

        public Team AwayTeam
        {
            get { return _awayTeam; }
        }

        public bool HasTeam(Team team)
        {
            return _homeTeam.Equals(team) || _awayTeam.Equals(team);
        }

        public int GoalsScored()
        {
            return _score.HomeGoals + _score.AwayGoals;
        }

        public int AwayGoals()
        {
            return _score.AwayGoals;
        }

        public int HomeGoals()
        {
            return _score.HomeGoals;
        }

        public int GoalsScoredBy(Team team)
        {
            if (team.Equals(_homeTeam))
                return _score.HomeGoals;

            return _score.AwayGoals;
        }

        public int GoalsConcededBy(Team team)
        {
            if (team.Equals(_homeTeam))
                return _score.AwayGoals;

            return _score.HomeGoals;
        }

        public bool IsBefore(DateTime date)
        {
            return _matchDate < date;
        }

        public bool IsOnOrAfter(DateTime date)
        {
            return _matchDate >= date;
        }

        public void Predict(Results results)
        {
            var expectedGoals = results.ExpectedGoalsFor(_homeTeam, this);

            _predictedScore = new Score(Convert.ToInt32(Math.Truncate(expectedGoals.Team)), Convert.ToInt32(Math.Truncate(expectedGoals.Opponent)));

            if (PredictionCorrect())
            {
                _predictionListener.AddCorrectPrediction();
            }
        }

        public void AddPredictionListener(PredictionListener listener)
        {
            _predictionListener = listener;
        }

        private bool PredictionCorrect()
        {
            return _score.Equals(_predictedScore);
        }

        #region Equality

        protected bool Equals(Fixture other)
        {
            return _matchDate.Equals(other._matchDate) && Equals(_homeTeam, other._homeTeam) && Equals(_awayTeam, other._awayTeam);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fixture) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _matchDate.GetHashCode();
                hashCode = (hashCode*397) ^ (_homeTeam != null ? _homeTeam.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_awayTeam != null ? _awayTeam.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_score != null ? _score.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

        #region Formatting

        public override string ToString()
        {
            return string.Format("MatchDate: {0}, HomeTeam: {1}, AwayTeam: {2}", _matchDate, _homeTeam, _awayTeam);
        }

        #endregion

    }
}