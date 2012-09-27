namespace DW.FantasyFootball.Domain
{
    public class ResultsRepository
    {
        private readonly IResultsStore _store;

        public ResultsRepository(IResultsStore store)
        {
            _store = store;
        }

        public Results For(int gamesweek, int season, int count)
        {
            if (_store.Exists(gamesweek, season, count))
            {
                return _store.For(gamesweek, season, count);
            }

            return new Results();
        }
    }
}