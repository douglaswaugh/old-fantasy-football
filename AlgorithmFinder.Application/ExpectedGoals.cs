namespace AlgorithmFinder.Application
{
    public class ExpectedGoals
    {
        private readonly decimal _forTeam;
        private readonly decimal _forOpponent;

        public ExpectedGoals(decimal forTeam, decimal forOpponent)
        {
            _forTeam = forTeam;
            _forOpponent = forOpponent;
        }

        public decimal ForTeam
        {
            get { return _forTeam; }
        }

        public decimal ForOpponent
        {
            get { return _forOpponent; }
        }

        #region Equality

        protected bool Equals(ExpectedGoals other)
        {
            return _forTeam == other._forTeam && _forOpponent == other._forOpponent;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ExpectedGoals) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_forTeam.GetHashCode()*397) ^ _forOpponent.GetHashCode();
            }
        }

        #endregion

        #region Formatting

        public override string ToString()
        {
            return string.Format("Team: {0}, Opponent: {1}", _forTeam, _forOpponent);
        }

        #endregion
    }
}