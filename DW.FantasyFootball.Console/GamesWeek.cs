using System;
using System.Collections;
using System.Collections.Generic;

namespace DW.FantasyFootball.Console
{
    public class Gamesweek : IEnumerable<Fixture>
    {
        private readonly List<Fixture> _fixtures;
        private bool _played;
        private bool _completed;

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
            foreach (var fixture in _fixtures)
            {
                if (fixture.HomeTeam == team || fixture.AwayTeam == team)
                    return fixture;
            }
        }

        public bool TeamHasPlayed(Team team)
        {
            return GetFixtureForTeam(team).Played == true;
        }
    }
}