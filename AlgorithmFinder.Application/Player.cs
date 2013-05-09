using AlgorithmFinder.Application.PointsCalculators;

namespace AlgorithmFinder.Application
{
    public class Player
    {
        private readonly int _id;
        private readonly string _name;
        private readonly PointsCalculator _pointsCalculator;
        private readonly FixtureHistory _fixtureHistory;

        public Player(int id, string name, PointsCalculator pointsCalculator, FixtureHistory fixtureHistory)
        {
            _name = name;
            _pointsCalculator = pointsCalculator;
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

        public decimal Assists
        {
            get { return _fixtureHistory.Assists; }
        }

        public decimal ExpectedPoints(DefencePointsMultiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals, Fixture fixture)
        {
            return _pointsCalculator.CalculatePoints(this, defenceMultiplier, team, expectedGoals, fixture);
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