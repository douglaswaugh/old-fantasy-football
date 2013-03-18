namespace AlgorithmFinder.Application
{
    public class Season
    {
        private readonly int _season;

        public Season(int season)
        {
            _season = season;
        }

        #region Equality

        protected bool Equals(Season other)
        {
            return _season == other._season;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Season) obj);
        }

        public override int GetHashCode()
        {
            return _season;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("Season: {0}", _season);
        }
    }
}