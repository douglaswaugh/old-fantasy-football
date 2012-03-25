using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using log4net;

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

        public Fixture GetNextGamesweeksFixture(Team team, ILog logger)
        {
            try
            {
                var gw = _gamesweeks.FirstOrDefault(g => g.Started == false);

                return gw.GetFixtureForTeam(team);
            }
            catch(Exception e)
            {
                if(logger.IsDebugEnabled)
                {
                    logger.Debug(e.Message);
                }
                
                throw new SeasonFinishedException();
            }
        }

        public Fixture GetLastFixture(Team team)
        {
            var nextGamesweek = _gamesweeks.Last(x => x.HasPlayed(team));

            return GetFixture(team, nextGamesweek);
        }

        private Fixture GetFixture(Team team, Gamesweek nextGamesweek)  
        {
            var nextGamesweekIndex = _gamesweeks.IndexOf(nextGamesweek);

            var lastGamesweek = _gamesweeks.Skip(nextGamesweekIndex - 1).Take(1).First();

            return lastGamesweek.GetFixtureForTeam(team);
        }

        public Fixture GetLastHomeFixture(Team team)
        {
            var gamesweek = _gamesweeks.Last(x => x.HasPlayed(team) && x.HasHomeGame(team));

            return gamesweek.GetFixtureForTeam(team);
        }

        public Fixture GetLastAwayFixture(Team team)
        {
            var gamesweek = _gamesweeks.Last(x => x.HasPlayed(team) && x.HasAwayGame(team));

            return gamesweek.GetFixtureForTeam(team);
        }

        public override string ToString()
        {
            return string.Format("Gamesweeks: {0}", _gamesweeks);
        }

        public IEnumerable<Fixture> GetLastXHomeFixturesForTeam(Team team, int fixtureCount)
        {
            var homeGames = _gamesweeks
                .Where(x => x.HasPlayed(team) && x.HasHomeGame(team))
                .Select(g => g.GetFixtureForTeam(team));

            return homeGames.Skip(homeGames.Count() - fixtureCount);
        }

        public IEnumerable<Fixture> GetLastXAwayFixturesForTeam(Team team, int fixtureCount)
        {
            var awayGames = _gamesweeks
                .Where(x => x.HasPlayed(team) && x.HasAwayGame(team))
                .Select(g => g.GetFixtureForTeam(team));

            return awayGames.Skip(awayGames.Count() - fixtureCount);
        }
    }
}