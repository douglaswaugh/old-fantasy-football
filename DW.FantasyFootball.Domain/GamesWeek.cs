using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DW.FantasyFootball.Domain
{
    public class Gamesweek : IEnumerable<Fixture>
    {
        public readonly List<Fixture> _fixtures;
        private bool _completed;
        private bool _started;

        public Gamesweek()
        {
            _fixtures = new List<Fixture>();
        }

        public bool Completed
        {
            get {
                return _completed;
            }
            set {
                _completed = value;
            }
        }

        public bool Started
        {
            get {
                return _started;
            }
            set {
                _started = value;
            }
        }

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

        public bool HasGame(Team team)
        {
            return _fixtures.Exists(x => x.HomeTeam == team || x.AwayTeam == team);
        }

        public bool HasPlayed(Team team)
        {
            var hasPlayed = false;

            if (GetFixtureForTeam(team) != null)
            {
                hasPlayed = GetFixtureForTeam(team).Played == true;
            }

            return hasPlayed;
        }

        public bool HasNotPlayed(Team team)
        {
            return GetFixtureForTeam(team).Played == false;
        }

        public bool HasHomeGame(Team team)
        {
            return GetFixtureForTeam(team).HomeTeam == team;
        }

        public bool HasAwayGame(Team team)
        {
            return GetFixtureForTeam(team).AwayTeam == team;
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