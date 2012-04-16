using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
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

                var option = System.Console.ReadKey();

                if (option.KeyChar == 'p')
                {
                    DownloadPlayerStats();
                }
                if (option.KeyChar == 'f')
                {
                    DownloadFixtures();
                }
                else
                {
                    CalculateFixtureStrength(_logger);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
            }

            System.Console.ReadKey(true);
        }

        private static void DownloadFixtures()
        {
            var fixtureScrapper = new FixtureScrapper();

            var fixtureList = fixtureScrapper.GetLeague();

            var serializer = new DataContractJsonSerializer(typeof(Gamesweek));
            
            var directory = Directory.CreateDirectory(string.Format(@"c:\apps\DW.FantasyFootball\data\fixtures\{0}", DateTime.Now.ToString("yyyyMMddHHmmss")));

            var i = 1;

            foreach (var gamesweek in fixtureList)
            {
                using (var file = File.Create(Path.Combine(directory.FullName, fixtureList + ".txt")))
                {
                    serializer.WriteObject(file, gamesweek);
                }

                i++;
            }
        }

        private static void DownloadPlayerStats()
        {
            var directory = Directory.CreateDirectory(string.Format(@"c:\apps\DW.FantasyFootball\data\playerStats\{0}", DateTime.Now.ToString("yyyyMMddHHmmss")));

            for (int i = 1; i < 700; i++)
            {
                var request = BuildPlayerRequest(i);

                try
                {
                    var response = request.GetResponse() as HttpWebResponse;

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            WriteResponseToFile(responseStream, Path.Combine(directory.FullName, i + ".txt"));
                        }
                    }
                }
                catch
                {
                    System.Console.WriteLine(string.Format("No player found with id {0}", i));
                }
            }
        }

        public static void WriteResponseToFile(Stream stream, string filePath)
        {
            using (var file = File.Create(filePath))
            {
                stream.CopyTo(file);

                System.Console.WriteLine(string.Format("Player {0} downloaded", filePath));
            }
        }

        private static HttpWebRequest BuildPlayerRequest(int playerId)
        {
            var request = WebRequest.Create(new Uri(string.Format("http://fantasy.premierleague.com/web/api/elements/{0}/", playerId))) as HttpWebRequest;

            request.Method = "GET";
            request.Host = "fantasy.premierleague.com";
            request.Headers.Add("X-Requested-With: XMLHttpRequest");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.46 Safari/535.11";
            request.Accept = "tetxt/html";
            request.Referer = "http://fantasy.premierleague.com/fixtures/";
            request.Headers.Add("Accept-Language: en-GB,en-US;q=0.8,en;q=0.6");
            request.Headers.Add("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            request.Headers.Add("Cache-Control: max-age=0");

            return request;
        }

        private static void CalculateFixtureStrength(ILog _logger)
        {
            var fixtureScrapper = new FixtureScrapper();

            var fixtureList = fixtureScrapper.GetLeague();

            var league = new League(fixtureList, _logger);

            var stats = new Stats();

            foreach (var teamData in league)
            {
                var nextFixtures = league.FixtureList.GetNextFixtures(teamData.Key, 11);

                foreach (var nextFixture in nextFixtures)
                {
                    // nextFixture = league.FixtureList.GetNextGamesweeksFixture(teamData.Key, _logger);

                    if (nextFixture == null)
                        break;

                    var homeFixtures = league.FixtureList.GetLastXHomeFixturesForTeam(nextFixture.HomeTeam, 6);

                    var awayFixtures = league.FixtureList.GetLastXAwayFixturesForTeam(nextFixture.AwayTeam, 6);

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