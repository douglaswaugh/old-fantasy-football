namespace AlgorithmFinder.Application
{
    public class Division
    {
        private readonly int _division;

        public Division(int division)
        {
            _division = division;
        }

        #region Equality
        protected bool Equals(Division other)
        {
            return _division == other._division;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Division) obj);
        }

        public override int GetHashCode()
        {
            return _division;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Division: {0}", _division);
        }
    }
}