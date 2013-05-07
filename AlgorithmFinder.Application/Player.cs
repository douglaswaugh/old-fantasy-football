using System.Runtime.Serialization;
using AlgorithmFinder.Application.PointsCalculators;

namespace AlgorithmFinder.Application
{
    [DataContract]
    public class Player
    {
        private readonly string _name;
        private readonly int _id;
        private readonly FixtureHistory _fixtureHistory;

        public Player(int id, string name, PointsCalculator pointsCalculator, FixtureHistory fixtureHistory)
        {
            _name = name;
            _fixtureHistory = fixtureHistory;
            _id = id;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Id
        {
            get { return _id; }
        }

        public FixtureHistory FixtureHistory
        {
            get { return _fixtureHistory; }
        }

        public decimal Goals
        {
            get { return _fixtureHistory.Goals; }
        }

        public decimal Saves
        {
            get { return _fixtureHistory.Saves; }
        }

        public decimal Bonus
        {
            get { return _fixtureHistory.Bonus; }
        }

        #region Equality

        protected bool Equals(Player other)
        {
            return _id == other._id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return _id;
        }

        #endregion
    }
}