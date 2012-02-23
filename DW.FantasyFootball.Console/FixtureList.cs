using System.Collections;
using System.Collections.Generic;

namespace DW.FantasyFootball.Console
{
    public class FixtureList : IEnumerable<GamesWeek>
    {
        private readonly List<GamesWeek> _gamesweeks;

        public FixtureList()
        {
            _gamesweeks = new List<GamesWeek>();
        }

        public IEnumerator<GamesWeek> GetEnumerator()
        {
            return _gamesweeks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(GamesWeek gamesWeek)
        {
            _gamesweeks.Add(gamesWeek);
        }
    }
}