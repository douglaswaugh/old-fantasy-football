using AlgorithmFinder.Application.PointsCalculators;

namespace AlgorithmFinder.Application
{
    public class Player
    {
        private readonly int _id;
        private readonly string _name;
        private readonly PointsCalculator _pointsCalculator;
        private readonly FixtureHistory _fixtureHistory;
        private readonly Team _team;

        public Player(int id, string name, PointsCalculator pointsCalculator, FixtureHistory fixtureHistory, Team team)
        {
            _name = name;
            _pointsCalculator = pointsCalculator;
            _fixtureHistory = fixtureHistory;
            _id = id;
            _team = team;
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

        public decimal YellowCards
        {
            get { return _fixtureHistory.YellowCards; }
        }

        public decimal RedCards
        {
            get { return _fixtureHistory.RedCards; }
        }

        public Team Team
        {
            get { return _team; }
        }

        public decimal ExpectedPoints(Fixture fixture, ExpectedGoalsCalculator expectedGoalsCalculator)
        {
            var redCardPoints = _fixtureHistory.RedCards * 3m;

            var yellowCardPoints = _fixtureHistory.YellowCards;

            var assistPoints = _fixtureHistory.Assists * 3m;

            var bonusPoints = _fixtureHistory.Bonus;

            var expectedGoals = expectedGoalsCalculator.ExpectedGoalsFor(Team, fixture);

            var defenceMultiplier = new PoissonDefencePointsMultiplier(expectedGoals.ForOpponent);

            var defencePoints = _pointsCalculator.DefencePoints(defenceMultiplier);

            var goalPoints = _pointsCalculator.GoalPoints(Team.GoalsRatioFor(_fixtureHistory.Goals), expectedGoals.ForTeam);

            return defencePoints + bonusPoints + goalPoints + assistPoints - yellowCardPoints - redCardPoints;
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