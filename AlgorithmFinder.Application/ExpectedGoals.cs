namespace AlgorithmFinder.Application
{
    public class ExpectedGoals
    {
        private readonly decimal _home;
        private readonly decimal _away;

        public ExpectedGoals(decimal home, decimal away)
        {
            _home = home;
            _away = away;
        }

        public decimal Home
        {
            get { return _home; }
        }

        public decimal Away
        {
            get { return _away; }
        }
        
        #region Equality
        protected bool Equals(ExpectedGoals other)
        {
            return _home == other._home && _away == other._away;
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
                return (_home.GetHashCode()*397) ^ _away.GetHashCode();
            }
        }
        #endregion

        #region Formatting
        public override string ToString()
        {
            return string.Format("Home: {0}, Away: {1}", _home, _away);
        }
        #endregion
    }
}