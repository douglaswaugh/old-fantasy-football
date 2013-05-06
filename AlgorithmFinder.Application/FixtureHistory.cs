using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmFinder.Application
{
    public class FixtureHistory
    {
        private readonly List<PlayerFixture> _playerFixtures = new List<PlayerFixture>();

        public FixtureHistory()
        {
        }

        public FixtureHistory(List<PlayerFixture> playerFixtures)
        {
            _playerFixtures = playerFixtures;
        }

        public decimal Saves
        {
            get { return Convert.ToDecimal(_playerFixtures.Average(f => f.Saves)) / 3m; }
        }

        public decimal Bonus
        {
            get { return Convert.ToDecimal(_playerFixtures.Average(f => f.Bonus)); }
        }

        public int Goals
        {
            get { return _playerFixtures.Sum(f => f.Goals); }
        }

        public void Add(PlayerFixture playerFixture)
        {
            _playerFixtures.Add(playerFixture);
        }
    }
}