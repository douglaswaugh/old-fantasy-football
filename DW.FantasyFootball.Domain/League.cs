using System.Collections;
using System.Collections.Generic;

namespace DW.FantasyFootball.Domain
{
    public class League : IEnumerable<KeyValuePair<Team, LeagueData>>
    {
        readonly Dictionary<Team, LeagueData> _league = new Dictionary<Team, LeagueData>();

        public League(FixtureList fixtureList)
        {
            Build(fixtureList);
        }

        public void Build(FixtureList fixtureList)
        {
            foreach (var gamesweek in fixtureList)
            {
                foreach (var fixture in gamesweek)
                {
                    if (!fixture.Played) continue;

                    var homeData = GetLeagueData(fixture.HomeTeam);

                    homeData.UpdateHomeData(fixture);

                    var awayData = GetLeagueData(fixture.AwayTeam);

                    awayData.UpdateAwayData(fixture);
                }
            }
        }

        private LeagueData GetLeagueData(Team team)
        {
            if (!_league.ContainsKey(team))
                _league.Add(team, new LeagueData());

            return _league[team];
        }

        public IEnumerator<KeyValuePair<Team, LeagueData>> GetEnumerator()
        {
            return _league.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}