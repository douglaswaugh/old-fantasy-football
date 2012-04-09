using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DW.FantasyFootball.Domain
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

        private Gamesweek NextGamesweek()
        {
            return _gamesweeks.FirstOrDefault(g => g.Started == false);
        }

        public override string ToString()
        {
            return string.Format("Gamesweeks: {0}", _gamesweeks);
        }

        public IEnumerable<Fixture> GetLastXHomeFixturesForTeam(Team team, int fixtureCount)
        {
            var homeGames = _gamesweeks
                .Where(g => g.Completed)
                .SelectMany(c => c.GetFixturesForTeam(team))
                .Where(f => f.HomeTeam == team);

            return homeGames.Skip(homeGames.Count() - fixtureCount);
        }

        public IEnumerable<Fixture> GetLastXAwayFixturesForTeam(Team team, int fixtureCount)
        {
            var awayGames = _gamesweeks
                .Where(g => g.Completed)
                .SelectMany(c => c.GetFixturesForTeam(team))
                .Where(f => f.AwayTeam == team);

            return awayGames.Skip(awayGames.Count() - fixtureCount);
        }

        public IEnumerable<Fixture> GetNextFixtures(Team team, int numberOfGamesweeks)
        {
            return _gamesweeks
                .Skip(_gamesweeks.IndexOf(NextGamesweek()))
                .Take(numberOfGamesweeks)
                .Where(g => g.GetFixturesForTeam(team).Any())
                .SelectMany(g => g.GetFixturesForTeam(team));
        }
    }
}