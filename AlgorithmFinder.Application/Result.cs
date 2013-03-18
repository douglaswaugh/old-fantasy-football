using System;

namespace AlgorithmFinder.Application
{
    public class Result
    {
        private readonly Season _season;
        private readonly Division _division;
        private readonly Shots _awayShotsOnTarget;
        private readonly Shots _awayShots;
        private readonly Shots _homeShotsOnTarget;
        private readonly Shots _homeShots;
        private readonly DateTime _matchDate;
        private readonly Team _homeTeam;
        private readonly Team _awayTeam;
        private readonly Score _score;

        public Result(Team homeTeam, Team awayTeam, DateTime matchDate, Score score, Shots homeShots, Shots homeShotsOnTarget, Shots awayShots, Shots awayShotsOnTarget, Division division, Season season)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _matchDate = matchDate;
            _score = score;
            _homeShots = homeShots;
            _homeShotsOnTarget = homeShotsOnTarget;
            _awayShots = awayShots;
            _awayShotsOnTarget = awayShotsOnTarget;
            _division = division;
            _season = season;
        }

        public Score Score()
        {
            return new Score(0, 0);
        }

        #region
        protected bool Equals(Result other)
        {
            return Equals(_season, other._season) && Equals(_division, other._division) && Equals(_awayShotsOnTarget, other._awayShotsOnTarget) && Equals(_awayShots, other._awayShots) && Equals(_homeShotsOnTarget, other._homeShotsOnTarget) && Equals(_homeShots, other._homeShots) && _matchDate.Equals(other._matchDate) && Equals(_homeTeam, other._homeTeam) && Equals(_awayTeam, other._awayTeam) && Equals(_score, other._score);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Result) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (_season != null ? _season.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_division != null ? _division.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_awayShotsOnTarget != null ? _awayShotsOnTarget.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_awayShots != null ? _awayShots.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_homeShotsOnTarget != null ? _homeShotsOnTarget.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_homeShots != null ? _homeShots.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _matchDate.GetHashCode();
                hashCode = (hashCode*397) ^ (_homeTeam != null ? _homeTeam.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_awayTeam != null ? _awayTeam.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_score != null ? _score.GetHashCode() : 0);
                return hashCode;
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Season: {0}, Division: {1}, AwayShotsOnTarget: {2}, AwayShots: {3}, HomeShotsOnTarget: {4}, HomeShots: {5}, MatchDate: {6}, HomeTeam: {7}, AwayTeam: {8}, Score: {9}", _season, _division, _awayShotsOnTarget, _awayShots, _homeShotsOnTarget, _homeShots, _matchDate, _homeTeam, _awayTeam, _score);
        }
    }
}