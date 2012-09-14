using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DW.FantasyFootball.Domain
{
    public class Gamesweek : IEnumerable<Fixture>
    {
        private readonly List<Fixture> _fixtures;

        public Gamesweek()
        {
            _fixtures = new List<Fixture>();
        }

        public List<Fixture> Fixtures
        {
            get { return _fixtures; }
        }

        public bool Completed { get; set; }

        public bool Started { get; set; }

        public void AddFixture(Fixture fixture)
        {
            _fixtures.Add(fixture);
        }

        public IEnumerator<Fixture> GetEnumerator()
        {
            return _fixtures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Fixture GetFixtureForTeam(Team team)
        {
            return _fixtures.OrderBy(x => x.Date).FirstOrDefault(f => f.AwayTeam == team || f.HomeTeam == team);
        }

        public IEnumerable<Fixture> GetFixturesForTeam(Team team)
        {
            return _fixtures.OrderBy(x => x.Date).Where(f => f.AwayTeam == team || f.HomeTeam == team);
        }

        public bool HasGame(Team team)
        {
            return _fixtures.Exists(x => x.HomeTeam == team || x.AwayTeam == team);
        }

        public bool HasPlayed(Team team)
        {
            var hasPlayed = false;

            if (GetFixturesForTeam(team).Any())
            {
                hasPlayed = GetFixturesForTeam(team).All(f => f.Played);
            }

            return hasPlayed;
        }

        public Fixture GetNextFixtureForTeam(Team team)
        {
            var unplayedGames = _fixtures.Where(x => !x.Played);

            return unplayedGames
                .OrderBy(x => x.Date)
                .First(x => x.HomeTeam == team || x.AwayTeam == team);
        }

        public override string ToString()
        {
            var formattedFixtures = new StringBuilder();

            foreach(var fixture in _fixtures)
            {
                formattedFixtures.AppendLine(fixture.ToString());
            }

            return string.Format("Fixtures: {0}", formattedFixtures);
        }
    }
}