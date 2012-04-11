using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DW.FantasyFootball.Domain
{
    public class Stats : IEnumerable<KeyValuePair<Team, StatFixtureList>>
    {
        private Dictionary<Team, StatFixtureList> _stats;

        public void AddFutureFixture(Team team, StatFixture statFixture)
        {
            if (_stats == null)
            {
                _stats = new Dictionary<Team, StatFixtureList>();
            }

            if (!_stats.ContainsKey(team))
            {
                _stats.Add(team, new StatFixtureList());
            }

            _stats[team].Add(statFixture);
        }

        public IEnumerator<KeyValuePair<Team, StatFixtureList>> GetEnumerator()
        {
            return _stats.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IOrderedEnumerable<KeyValuePair<Team, StatFixtureList>> OrderedByDefensivePoints()
        {
            return _stats
                .OfType<KeyValuePair<Team, StatFixtureList>>()
                .OrderBy(s => s.Value.DefensivePointsAverage);
        }

        public IOrderedEnumerable<KeyValuePair<Team, StatFixtureList>> OrderedByOffensivePointsAverage()
        {
            return _stats
                .OfType<KeyValuePair<Team, StatFixtureList>>()
                .OrderByDescending(s => s.Value.OffensivePointsAverage);
        }

        public IOrderedEnumerable<KeyValuePair<Team, StatFixtureList>> OrderedByProbabilityOfAtLeastOneCleanSheet()
        {
            return _stats
                .OfType<KeyValuePair<Team, StatFixtureList>>()
                .OrderByDescending(s => s.Value.ProbabilityOfAtLeastOneCleanSheet);
        }

        public IOrderedEnumerable<KeyValuePair<Team, StatFixtureList>> OrderedByOffensivePointsTotal()
        {
            return _stats
                .OfType<KeyValuePair<Team, StatFixtureList>>()
                .OrderByDescending(s => s.Value.OffensivePointsTotal);
        }
    }
}