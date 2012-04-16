using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace DW.FantasyFootball.Domain
{
    public class FixtureScrapper
    {
        public FixtureList GetLeague()
        {
            var fixtureList = new FixtureList();

            for (int weekNumber = 1; weekNumber <= 38; weekNumber++)
            {
                HtmlDocument document = GetFixturesFromWebsite(weekNumber);

                IEnumerable<HtmlNode> fixtureRows = GetFixtureRows(document);

                Gamesweek gamesweek = BuildGamesWeekData(fixtureRows);

                fixtureList.Add(gamesweek);

                Console.WriteLine(String.Format("Processed gamesweek {0}", weekNumber));
            }

            return fixtureList;
        }

        private HtmlDocument GetFixturesFromWebsite(int i)
        {
            HttpWebRequest request = GetRequest(i);

            var response = request.GetResponse() as HttpWebResponse;

            return GetDocument(response);
        }

        private Gamesweek BuildGamesWeekData(IEnumerable<HtmlNode> fixtureRows)
        {
            var gamesWeek = new Gamesweek();

            var completed = true;

            var started = false;

            foreach (var row in fixtureRows)
            {
                Fixture fixture = GetFixture(row);

                gamesWeek.AddFixture(fixture);

                if (!fixture.Played)
                    completed = false;

                if (fixture.Played)
                    started = true;
            }

            gamesWeek.Completed = completed;

            gamesWeek.Started = started;

            return gamesWeek;
        }

        private HtmlDocument GetDocument(HttpWebResponse response)
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

        private IEnumerable<HtmlNode> GetFixtureRows(HtmlDocument document)
        {
            var fixtureRows = document.DocumentNode.SelectNodes("//tr[@class=\"ismFixture\"] | //tr[@class=\"ismFixture ismResult\"] | //tr[@class=\"ismResult\"]");

            return fixtureRows;
        }

        private Fixture GetFixture(HtmlNode row)
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

        private int GetAwayScore(string innerText)
        {
            return Int32.Parse(innerText.Split(' ')[2]);
        }

        private int GetHomeScore(string innerText)
        {
            return Int32.Parse(innerText.Split(' ')[0]);
        }

        private HttpWebRequest GetRequest(int i)
        {
            var request = WebRequest.Create(new Uri(string.Format("http://fantasy.premierleague.com/fixtures/{0}/", i))) as HttpWebRequest;

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

        private DateTime GetDateFromText(string innerText)
        {
            string[] date = innerText.Split(' ');

            int day = Int32.Parse(date[0]);

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

            int hour = Int32.Parse(time[0]);

            int minutes = Int32.Parse(time[1]);

            int year = (month > 7) ? 2011 : 2012; 

            return new DateTime(year, month, day, hour, minutes, 0);
        }
    }
}
