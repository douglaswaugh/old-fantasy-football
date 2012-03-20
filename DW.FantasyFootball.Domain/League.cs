using System;
using System.Collections;
using System.Collections.Generic;
using log4net;

namespace DW.FantasyFootball.Domain
{
    public class League : IEnumerable<KeyValuePair<Team, LeagueData>>
    {
        private readonly FixtureList _fixtureList;
        private readonly ILog _logger;

        private Dictionary<Team, LeagueData> _league;

        public League(FixtureList fixtureList, ILog logger)
        {
            _fixtureList = fixtureList;
            _logger = logger;
            _league = new Dictionary<Team, LeagueData>();

            // not sure about this.  I think it might be a bit much in a constructor
            Build();
        }

        public FixtureList FixtureList
        {
            get
            {
                return _fixtureList;
            }
        }

        private void Build()
        {
            foreach (var gamesweek in _fixtureList)
            {
                foreach (var fixture in gamesweek)
                {
                    if (fixture.Played)
                    {
                        var homeData = GetLeagueData(fixture.HomeTeam);

                        homeData.UpdateHomeData(fixture);

                        var awayData = GetLeagueData(fixture.AwayTeam);

                        awayData.UpdateAwayData(fixture);
                    }
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