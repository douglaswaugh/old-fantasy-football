using System.Collections;
using System.Collections.Generic;

namespace DW.FantasyFootball.Domain
{
    public class Results : IEnumerable<Result>
    {
        private readonly List<Result> _results = new List<Result>();

        public void Add(Result result)
        {
            _results.Add(result);
        }

        public IEnumerator<Result> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}