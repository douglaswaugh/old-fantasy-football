namespace AlgorithmFinder.Application
{
    public class Team
    {
        private readonly string _name;

        public Team(string name)
        {
            _name = name;
        }

        #region Equality

        protected bool Equals(Team other)
        {
            return string.Equals(_name, other._name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Team) obj);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        #endregion

        public override string ToString()
        {
            return string.Format("Name: {0}", _name);
        }
    }
}