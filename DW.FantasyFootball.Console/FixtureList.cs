using System.Collections;
using System.Collections.Generic;

namespace DW.FantasyFootball.Console
{
    public class FixtureList : IEnumerable<Gamesweek>
    {
        private readonly List<Gamesweek> _gamesweeks;

        public FixtureList()
        {
            _gamesweeks = new List<Gamesweek>();
        }

        public IEnumerator<Gamesweek> GetEnumerator()
        {
            return _gamesweeks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Gamesweek gamesweek)
        {
            _gamesweeks.Add(gamesweek);
        }

        public Fixture GetNextFixture(Team team)
        {
            foreach(var gamesweek in _gamesweeks)
            {
                if (!gamesweek.Completed)
                {
                    if (!gamesweek.TeamHasPlayed(team))
                    {
                        return gamesweek.GetFixtureForTeam(team);
                    }
                }
            }

            throw new SeasonFinishedException();
        }
    }
}