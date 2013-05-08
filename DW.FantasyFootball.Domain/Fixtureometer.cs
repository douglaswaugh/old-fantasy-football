using System.Linq;
using log4net;

namespace DW.FantasyFootball.Domain
{
    public class Fixtureometer
    {
        private readonly FixtureScrapper _fixtureScrapper;

        public Fixtureometer(FixtureScrapper fixtureScrapper)
        {
            _fixtureScrapper = fixtureScrapper;
        }

        public void CalculateFixtureStrength(ILog _logger)
        {
            var fixtureList = _fixtureScrapper.GetFixtureList();

            var league = new League(fixtureList);

            var stats = new Stats();

            foreach (var teamData in league)
            {
                var nextFixtures = fixtureList.GetNextFixtures(teamData.Key, 11);

                foreach (var nextFixture in nextFixtures)
                {
                    if (nextFixture == null)
                        break;

                    var homeFixtures = fixtureList.GetLastXHomeFixturesForTeam(nextFixture.HomeTeam, 6).ToList();

                    var awayFixtures = fixtureList.GetLastXAwayFixturesForTeam(nextFixture.AwayTeam, 6).ToList();

                    var expectedHomeGoals = (homeFixtures.Average(f => (decimal)f.HomeGoals) + awayFixtures.Average(f => (decimal)f.HomeGoals)) / 2m;

                    var expectedAwayGoals = (awayFixtures.Average(f => (decimal)f.AwayGoals) + homeFixtures.Average(f => (decimal)f.AwayGoals)) / 2m;

                    if (nextFixture.HomeTeam == teamData.Key)
                    {
                        stats.AddFutureFixture(nextFixture.HomeTeam, new StatFixture(expectedHomeGoals, expectedAwayGoals));
                    }
                    else
                    {
                        stats.AddFutureFixture(nextFixture.AwayTeam, new StatFixture(expectedAwayGoals, expectedHomeGoals));
                    }

                    /*System.Console.WriteLine(
                            string.Format("{0} v {1} for {2} against {3}",
                            nextFixture.HomeTeam,
                            nextFixture.AwayTeam,
                            expectedHomeGoals.ToString("{0.00}"),
                            expectedAwayGoals.ToString("{0.00}"))
                        );*/
                }
            }

            System.Console.WriteLine("\nDefensive Stats");

            foreach (var stat in stats.OrderedByProbabilityOfAtLeastOneCleanSheet())
            {
                System.Console.WriteLine(stat.Key.Name + " " + stat.Value.ProbabilityOfAtLeastOneCleanSheet);
            }

            System.Console.WriteLine("\nOffensive Stats Total");

            foreach (var stat in stats.OrderedByOffensivePointsTotal())
            {
                System.Console.WriteLine(stat.Key.Name + " " + stat.Value.OffensivePointsTotal);
            }

            System.Console.WriteLine("\nOffensive Stats Average");

            foreach (var stat in stats.OrderedByOffensivePointsAverage())
            {
                System.Console.WriteLine(stat.Key.Name + " " + stat.Value.OffensivePointsAverage);
            }

            System.Console.WriteLine("\nGames Remaining");

            foreach (var stat in stats)
            {
                System.Console.WriteLine(stat.Key.Name + " " + stat.Value.Count());
            }
        }
    }
}