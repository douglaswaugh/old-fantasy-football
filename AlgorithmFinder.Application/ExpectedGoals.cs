namespace AlgorithmFinder.Application
{
    public class ExpectedGoals
    {
        private readonly decimal _expectedHomeGoals;
        private readonly decimal _expectedAwayGoals;

        public ExpectedGoals(decimal expectedHomeGoals, decimal expectedAwayGoals)
        {
            _expectedHomeGoals = expectedHomeGoals;
            _expectedAwayGoals = expectedAwayGoals;
        }

        public decimal ExpectedHomeGoals
        {
            get { return _expectedHomeGoals; }
        }

        public decimal ExpectedAwayGoals
        {
            get { return _expectedAwayGoals; }
        }
        
        #region Equality
        protected bool Equals(ExpectedGoals other)
        {
            return _expectedHomeGoals == other._expectedHomeGoals && _expectedAwayGoals == other._expectedAwayGoals;
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
                return (_expectedHomeGoals.GetHashCode()*397) ^ _expectedAwayGoals.GetHashCode();
            }
        }
        #endregion

        #region Formatting
        public override string ToString()
        {
            return string.Format("ExpectedHomeGoals: {0}, ExpectedAwayGoals: {1}", _expectedHomeGoals, _expectedAwayGoals);
        }
        #endregion
    }
}