using System;
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

                foreach(var teamData in league)
                {
                    var nextFixture = league.FixtureList.GetNextGamesweeksFixture(teamData.Key, _logger);

                    // 
                    decimal expectedHomeGoals;
                        
                    decimal expectedAwayGoals;

                    if (nextFixture == null)
                        break;

                    if (nextFixture.HomeTeam == teamData.Key)
                    {
                        var homeFixture = league.FixtureList.GetLastHomeFixture(teamData.Key);
                        
                        var awayFixture = league.FixtureList.GetLastAwayFixture(nextFixture.AwayTeam);

                        expectedHomeGoals = (homeFixture.HomeGoals + awayFixture.HomeGoals)/2m;

                        expectedAwayGoals = (awayFixture.AwayGoals + homeFixture.AwayGoals)/2m;
                    }
                    else
                    {
                        var homeFixture = league.FixtureList.GetLastHomeFixture(nextFixture.HomeTeam);

                        var awayFixture = league.FixtureList.GetLastAwayFixture(teamData.Key);

                        expectedHomeGoals = (homeFixture.HomeGoals + awayFixture.HomeGoals) / 2m;

                        expectedAwayGoals = (awayFixture.AwayGoals + homeFixture.AwayGoals) / 2m;
                        
                    }

                    System.Console.WriteLine(string.Format("{0} {1} - {2} {3}", nextFixture.HomeTeam, expectedHomeGoals, expectedAwayGoals, nextFixture.AwayTeam));

                    // work out poisson on averages 
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
            }

            System.Console.ReadKey(true);
        }
    }

    public class StrengthCalculator
    {
    }
}