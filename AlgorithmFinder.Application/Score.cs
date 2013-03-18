namespace AlgorithmFinder.Application
{
    public class Score
    {
        private readonly int _homeGoals;
        private readonly int _awayGoals;

        public Score(int homeGoals, int awayGoals)
        {
            _homeGoals = homeGoals;
            _awayGoals = awayGoals;
        }

        #region Equality
        protected bool Equals(Score other)
        {
            return _homeGoals == other._homeGoals && _awayGoals == other._awayGoals;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Score) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_homeGoals*397) ^ _awayGoals;
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format("HomeGoals: {0}, AwayGoals: {1}", _homeGoals, _awayGoals);
        }
    }
}