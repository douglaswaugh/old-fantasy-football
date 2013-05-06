using System.Collections;
using System.Collections.Generic;

namespace AlgorithmFinder.Application
{
    public class Fixtures : IEnumerable<Fixture>
    {
        private readonly List<Fixture> _fixtures = new List<Fixture>();

        public Fixtures(List<Fixture> fixtures)
        {
            _fixtures = fixtures;
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