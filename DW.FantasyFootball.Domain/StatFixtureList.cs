using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DW.FantasyFootball.Domain
{
    public class StatFixtureList : IEnumerable<StatFixture>
    {
        private List<StatFixture> _statFixtures;

        public void Add(StatFixture statFixture)
        {
            if (_statFixtures == null)
            {
                _statFixtures = new List<StatFixture>();
            }

            _statFixtures.Add(statFixture);
        }

        public decimal DefensivePointsAverage
        {
            get { return _statFixtures.Average(s => s.GoalsAgainst); }
        }

        public decimal OffensivePointsAverage
        {
            get { return _statFixtures.Average(s => s.GoalsFor); }
        }

        public double ProbabilityOfAtLeastOneCleanSheet
        {
            get { return 1.0 - _statFixtures.Aggregate(1.0, (x, y) => x * (1.0 - y.ProbabilityOfCleanSheet)); }
        }

        public decimal OffensivePointsTotal
        {
            get { return _statFixtures.Sum(s => s.GoalsFor); }
        }

        public IEnumerator<StatFixture> GetEnumerator()
        {
            return _statFixtures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}