using System;

namespace AlgorithmFinder.Application
{
    public class Fixture
    {
        private readonly DateTime _matchDate;
        private readonly Team _homeTeam;
        private readonly Team _awayTeam;
        private readonly Score _score;
        private Prediction _prediction;

        public Fixture(Team homeTeam, Team awayTeam, DateTime matchDate, Score score)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _matchDate = matchDate;
            _score = score;
        }

        public Fixture(Team homeTeam, Team awayTeam)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
        }

        public Team HomeTeam
        {
            get { return _homeTeam; }
        }

        public Team AwayTeam
        {
            get { return _awayTeam; }
        }

        public bool PredictionCorrect
        {
            get { return _prediction.MostLikelyScoreIs(_score); }
        }

        public DateTime MatchDate
        {
            get { return _matchDate; }
        }

        public bool HasTeam(Team team)
        {
            return _homeTeam.Equals(team) || _awayTeam.Equals(team);
        }

        public int GoalsScored()
        {
            return _score.HomeGoals + _score.AwayGoals;
        }

        public Prediction Predict(Results results, ProbabilityCalculator probabilityCalculator)
        {
            var expectedGoals = results.ExpectedGoalsFor(this);

            _prediction = new Prediction(probabilityCalculator.GetPrediction(expectedGoals));

            return _prediction;
        }

        public int AwayGoals()
        {
            return _score.AwayGoals;
        }

        public int GoalsScoredBy(Team team)
        {
            if (team.Equals(_homeTeam))
                return _score.HomeGoals;

            return _score.AwayGoals;
        }

        public int HomeGoals()
        {
            return _score.HomeGoals;
        }

        public int GoalsConcededBy(Team team)
        {
            if (team.Equals(_homeTeam))
                return _score.AwayGoals;

            return _score.HomeGoals;
        }

        public bool FixtureFor(int teamId)
        {
            return _homeTeam.Id.Equals(teamId) || _awayTeam.Id.Equals(teamId);
        }

        public decimal ExpectedPointsFor(Player player, Team team, ExpectedGoalsCalculator results, IPrediction prediction)
        {
            // yellow cards
            // red cards

            var expectedPoints = 0m;
            var expectedGoals = 0m;

            if (team.Id.Equals(_homeTeam.Id))
            {
                expectedPoints += prediction.DefencePointsForHomeTeam();
                expectedGoals = results.ExpectedHomeGoals(this);
            }
            else
            {
                expectedPoints += prediction.DefencePointsForAwayTeam();
                expectedGoals = results.ExpectedAwayGoals(this);
            }

            expectedPoints += player.FixtureHistory.Saves;

            expectedPoints += player.FixtureHistory.Bonus;

            expectedPoints += expectedGoals * team.GoalsRatioFor(player) * 6;

            // assists

            return expectedPoints;
        }

        #region Equality
        protected bool Equals(Fixture other)
        {
            return _matchDate.Equals(other._matchDate) && Equals(_homeTeam, other._homeTeam) && Equals(_awayTeam, other._awayTeam) && Equals(_score, other._score) && Equals(_prediction, other._prediction);
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
                hashCode = (hashCode*397) ^ (_prediction != null ? _prediction.GetHashCode() : 0);
                return hashCode;
            }
        }
        #endregion

        #region Formatting

        public override string ToString()
        {
            return string.Format("MatchDate: {0}, HomeTeam: {1}, AwayTeam: {2}, Score: {3}, Prediction: {4}", _matchDate, _homeTeam, _awayTeam, _score, _prediction);
        }

        #endregion
    }
}