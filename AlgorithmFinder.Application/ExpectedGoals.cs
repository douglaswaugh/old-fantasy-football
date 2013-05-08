namespace AlgorithmFinder.Application
{
    public class ExpectedGoals
    {
        private readonly decimal _team;
        private readonly decimal _opponent;

        public ExpectedGoals(decimal team, decimal opponent)
        {
            _team = team;
            _opponent = opponent;
        }

        public decimal Team
        {
            get { return _team; }
        }

        public decimal Opponent
        {
            get { return _opponent; }
        }

        #region Equality

        protected bool Equals(ExpectedGoals other)
        {
            return _team == other._team && _opponent == other._opponent;
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
                return (_team.GetHashCode()*397) ^ _opponent.GetHashCode();
            }
        }

        #endregion

        #region Formatting

        public override string ToString()
        {
            return string.Format("Team: {0}, Opponent: {1}", _team, _opponent);
        }

        #endregion
    }
}