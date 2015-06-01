using System;
using System.IO;
using System.Net;
using DW.FantasyFootball.Domain;
using log4net;

namespace DW.FantasyFootball.Console
{
    class Program
    {
        static void Main()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();

                ILog _logger = LogManager.GetLogger("logger");

                var option = System.Console.ReadKey();

                switch (option.KeyChar)
                {
                    case 'p':
                        DownloadPlayerStats();
                        break;
                    case 'f':
                        DownloadFixtures();
                        break;
                    case 'b':
                        var suggestor = new PlayerSuggestor();
                        System.Console.WriteLine(suggestor.SuggestPlayerToBuy().ToString());
                        break;
                    default:
                        var fixtureometer = new Fixtureometer(new FixtureScrapper());

                        fixtureometer.CalculateFixtureStrength(_logger);
                        break;
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

            var fixtureList = fixtureScrapper.GetFixtureList();
            
            fixtureList.Save();
        }

        private static void DownloadPlayerStats()
        {
            var directory = Directory.CreateDirectory(string.Format(@"c:\Repos\fantasy-football.data\data\playerStats\{0}", DateTime.Now.ToString("yyyyMMddHHmmss")));

            for (int i = 1; i < 800; i++)
            {
                var request = BuildPlayerRequest(i);

                try
                {
                    var response = request.GetResponse() as HttpWebResponse;

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            WriteResponseToFile(responseStream, Path.Combine(directory.FullName, i + ".json"), i);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine("No player found with id {0}", i);
                }
            }
        }

        public static void WriteResponseToFile(Stream stream, string filePath, int playerId)
        {
            using (var file = File.Create(filePath))
            {
                stream.CopyTo(file);

                System.Console.WriteLine("Player {0} downloaded", playerId);
            }
        }

        private static HttpWebRequest BuildPlayerRequest(int playerId)
        {
            var request = WebRequest.Create(new Uri(string.Format("http://fantasy.premierleague.com/web/api/elements/{0}/", playerId))) as HttpWebRequest;

            request.Method = "GET";
            request.Host = "fantasy.premierleague.com";
            request.Headers.Add("X-Requested-With: XMLHttpRequest");
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.46 Safari/535.11";
            request.Accept = "application/json";
            request.Referer = "http://fantasy.premierleague.com/fixtures/";
            request.Headers.Add("Accept-Language: en-GB,en-US;q=0.8,en;q=0.6");
            request.Headers.Add("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            request.Headers.Add("Cache-Control: max-age=0");

            return request;
        }
    }
}