using System.Collections.Generic;

namespace AlgorithmFinder.Application
{
    public class Shots
    {
        private readonly int _shots;

        public Shots(int shots)
        {
            _shots = shots;
        }

        #region Equality
        protected bool Equals(Shots other)
        {
            return _shots == other._shots;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Shots) obj);
        }

        public override int GetHashCode()
        {
            return _shots;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Shots: {0}", _shots);
        }
    }
}