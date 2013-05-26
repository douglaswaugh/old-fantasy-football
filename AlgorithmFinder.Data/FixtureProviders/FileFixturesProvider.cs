using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data.FixtureProviders
{
    public class FileFixturesProvider : FixturesProvider
    {
        private IEnumerable<Fixture> _results;
        private readonly FixtureParser _parser;

        public FileFixturesProvider(FixtureParser parser)
        {
            _parser = parser;
        }

        public Fixtures GetFixturesAfter(DateTime date)
        {
            if (_results == null)
            {
                BuildFixtures();
            }

            return new Fixtures(_results.Where(r => r.IsOnOrAfter(date)).ToList());
        }

        public Fixtures GetFixturesAfter(DateTime date, Team team)
        {
            if (_results == null)
            {
                BuildFixtures();
            }

            return new Fixtures(GetFixturesAfter(date).Where(r => r.HasTeam(team)).ToList());
        }

        private void BuildFixtures()
        {
            _results = _parser.GetFixtures();
        }
    }
}