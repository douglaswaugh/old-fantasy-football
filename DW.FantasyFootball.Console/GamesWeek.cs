using System.Collections;
using System.Collections.Generic;

namespace DW.FantasyFootball.Console
{
    public class GamesWeek : IEnumerable<Fixture>
    {
        private readonly List<Fixture> _fixtures;

        public GamesWeek()
        {
            _fixtures = new List<Fixture>();
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
    }
}