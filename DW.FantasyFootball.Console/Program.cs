using System;
using System.Collections.Generic;
using System.Linq;
using DW.FantasyFootball.Domain;
using log4net;

namespace DW.FantasyFootball.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();

                ILog _logger = LogManager.GetLogger("logger");

                var fixtureList = FixtureScrapper.GetLeague();

                var league = new League(fixtureList, _logger);

                var stats = new Stats();

                foreach(var teamData in league)
                {
                    var nextFixture = league.FixtureList.GetNextGamesweeksFixture(teamData.Key, _logger);
 
                    decimal expectedTeamGoals;
                        
                    decimal expectedOpponentGoals;

                    if (nextFixture == null)
                        break;

                    if (nextFixture.HomeTeam == teamData.Key)
                    {
                        var homeFixtures = league.FixtureList.GetLastXHomeFixturesForTeam(teamData.Key, 6);
                        
                        var awayFixtures = league.FixtureList.GetLastXAwayFixturesForTeam(nextFixture.AwayTeam, 6);

                        expectedTeamGoals = (homeFixtures.Average(f => (decimal)f.HomeGoals) + awayFixtures.Average(f => (decimal)f.HomeGoals)) / 2m;

                        expectedOpponentGoals = (awayFixtures.Average(f => (decimal)f.AwayGoals) + homeFixtures.Average(f => (decimal)f.AwayGoals))/2m;
                    }
                    else
                    {
                        var awayFixtures = league.FixtureList.GetLastXAwayFixturesForTeam(teamData.Key, 6);

                        var homeFixtures = league.FixtureList.GetLastXHomeFixturesForTeam(nextFixture.HomeTeam, 6);

                        expectedOpponentGoals = (homeFixtures.Average(f => (decimal)f.HomeGoals) + awayFixtures.Average(f => (decimal)f.HomeGoals)) / 2m;

                        expectedTeamGoals = (awayFixtures.Average(f => (decimal)f.AwayGoals) + homeFixtures.Average(f => (decimal)f.AwayGoals)) / 2m;
                    }

                    stats.AddFutureFixture(teamData.Key, new StatFixture(expectedTeamGoals, expectedOpponentGoals));

                    System.Console.WriteLine(string.Format("{0} v {1} for {2} against {3}", teamData.Key,  expectedTeamGoals.ToString("{0.00}"), expectedOpponentGoals.ToString("{0.00}")));
                }

                System.Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
            }

            System.Console.ReadKey(true);
        }
    }

    public class StatFixture
    {
        private readonly decimal _expectedTeamGoals;
        private readonly decimal _expectedOpponentGoals;

        public StatFixture(decimal expectedTeamGoals, decimal expectedOpponentGoals)
        {
            _expectedTeamGoals = expectedTeamGoals;
            _expectedOpponentGoals = expectedOpponentGoals;
        }
    }

    public class Stats
    {
        private Dictionary<Team, List<StatFixture>> _stats;

        public void AddFutureFixture(Team team, StatFixture statFixture)
        {
            if (_stats == null)
            {
                _stats = new Dictionary<Team, List<StatFixture>>();
            }

            if (!_stats.ContainsKey(team))
            {
                _stats.Add(team, new List<StatFixture>());
            }

            _stats[team].Add(statFixture);
        }
    }

    public class StrengthCalculator
    {
    }
}