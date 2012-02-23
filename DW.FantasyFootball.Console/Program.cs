using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Threading;
using HtmlAgilityPack;

namespace DW.FantasyFootball.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var fixtureList = new FixtureList();

                for (int weekNumber = 1; weekNumber <= 38; weekNumber++)
                {
                    HtmlDocument document = GetFixturesFromWebsite(weekNumber);

                    IEnumerable<HtmlNode> fixtureRows = GetFixtureRows(document);

                    GamesWeek gamesWeek = BuildGamesWeekData(fixtureRows);

                    fixtureList.Add(gamesWeek);

                    System.Console.WriteLine(string.Format("Processed gamesweek {0}", weekNumber));
                }

                var league = new League(fixtureList);

                var leaguePrinter = new LeaguePrinter(league);

                // which team had the most clean sheets at home

                // which team conceeded the fewest goals at home

                leaguePrinter.ByHomeGoalsConceededAsc();

                leaguePrinter.ByAwayGoalsScoredDesc();

                leaguePrinter.ByAwayGoalsConceeded();

                leaguePrinter.ByHomeGoalsScoredDesc();

                var calc = new StrengthCalculator();

                foreach (var teamData in league)
                {
                    teamData.Key.HomeDefenceMultiplier = teamData.Value.HomeGoalsAgainst;

                    // what I want to do is:
                    // get a team
                    // calculate the next fixture for that team
                    // 
                }

                // need to take goals and assists in to account (but who were goals and assists scored against?)
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        private static HtmlDocument GetFixturesFromWebsite(int i)
        {
            HttpWebRequest request = GetRequest(i);

            var response = request.GetResponse() as HttpWebResponse;

            return GetDocument(response);
        }

        private static GamesWeek BuildGamesWeekData(IEnumerable<HtmlNode> fixtureRows)
        {
            var gamesWeek = new GamesWeek();

            foreach (var row in fixtureRows)
            {
                Fixture fixture = GetFixture(row);

                gamesWeek.AddFixture(fixture);
            }
            return gamesWeek;
        }

        private static HtmlDocument GetDocument(HttpWebResponse response)
        {
            string responseString;

            using (Stream responseStream = response.GetResponseStream())
            {
                var reader = new StreamReader(responseStream);

                responseString = reader.ReadToEnd();
            }

            var document = new HtmlDocument();

            document.LoadHtml(responseString);
            return document;
        }

        private static IEnumerable<HtmlNode> GetFixtureRows(HtmlDocument document)
        {
            var fixtureRows = document.DocumentNode.SelectNodes("//tr[@class=\"ismFixture\"]");

            if (fixtureRows == null)
            {
                fixtureRows = document.DocumentNode.SelectNodes("//tr[@class=\"ismFixture ismResult\"]");
            }
            return fixtureRows;
        }

        private static Fixture GetFixture(HtmlNode row)
        {
            var fixture = new Fixture();

            fixture.Date = GetDateFromText(row.ChildNodes[1].InnerText);
            fixture.HomeTeam = new Team(row.ChildNodes[3].InnerText);
            fixture.AwayTeam = new Team(row.ChildNodes[11].InnerText);
            if (row.ChildNodes[7].InnerText != "v")
            {
                fixture.Played = true;
                fixture.HomeGoals = GetHomeScore(row.ChildNodes[7].InnerText);
                fixture.AwayGoals = GetAwayScore(row.ChildNodes[7].InnerText);
            }

            return fixture;
        }

        private static int GetAwayScore(string innerText)
        {
            return int.Parse(innerText.Split(' ')[2]);
        }

        private static int GetHomeScore(string innerText)
        {
            return int.Parse(innerText.Split(' ')[0]);
        }

        private static HttpWebRequest GetRequest(int i)
        {
            var request =
                WebRequest.Create(new Uri(string.Format("http://fantasy.premierleague.com/fixtures/{0}/", i))) as HttpWebRequest;

            request.Method = "GET";
            request.Host = "fantasy.premierleague.com";
            request.Headers.Add("X-Requested-With: XMLHttpRequest");
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.46 Safari/535.11";
            request.Accept = "tetxt/html";
            request.Referer = "http://fantasy.premierleague.com/fixtures/";
            request.Headers.Add("Accept-Language: en-GB,en-US;q=0.8,en;q=0.6");
            request.Headers.Add("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            request.Headers.Add("Cache-Control: max-age=0");
            return request;
        }

        private static DateTime GetDateFromText(string innerText)
        {
            string[] date = innerText.Split(' ');

            int day = int.Parse(date[0]);

            var months = new Dictionary<string, int>()
                             {
                                 {"Jan", 1},
                                 {"Feb",2},
                                 {"Mar",3},
                                 {"Apr",4},
                                 {"May",5},
                                 {"Jun",6},
                                 {"Jul",7},
                                 {"Aug",8},
                                 {"Sep",9},
                                 {"Oct",10},
                                 {"Nov",11},
                                 {"Dec",12},
                             };

            int month = months[date[1]];

            string[] time = date[2].Split(':');

            int hour = int.Parse(time[0]);

            int minutes = int.Parse(time[1]);

            return new DateTime(2012, month, day, hour, minutes, 0);
        }
    }

    public class StrengthCalculator
    {
    }
}