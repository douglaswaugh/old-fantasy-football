using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AlgorithmFinder.Application;
using AlgorithmFinder.Data;
using AlgorithmFinder.Data.FixtureProviders;
using NSubstitute;

namespace AlgorithmFinder.LeagueUI
{
    class Program
    {
        static void Main()
        {
            var stream = new MemoryStream();

            var writer = new StreamWriter(stream);

            writer.Write(Data.Last6Games2012);

            writer.Flush();

            stream.Position = 0;

            var streamer = Substitute.For<Streamer>();
            streamer.GetStreamReaderFor(string.Empty).Returns(new StreamReader(stream));

            var parser = new CsvFileFixtureParser(streamer, string.Empty);
            var league = new Dictionary<string, LeagueData>();
            int homeGoals = 0;
            int awayGoals = 0;
            int gamesPlayed = 0;
            IEnumerable<Fixture> results;

            results = parser.GetFixtures().ToList();

            foreach (var result in results)
            {
                if (!league.ContainsKey(result.HomeTeam.Name))
                {
                    league.Add(result.HomeTeam.Name, new LeagueData());
                }
                if (!league.ContainsKey(result.AwayTeam.Name))
                {
                    league.Add(result.AwayTeam.Name, new LeagueData());
                }

                var homeLeagueData = league[result.HomeTeam.Name];
                homeLeagueData.GoalsScored += result.HomeGoals();
                homeLeagueData.GoalsConceded += result.AwayGoals();
                homeLeagueData.GamesPlayed++;

                var awayLeagueData = league[result.AwayTeam.Name];
                awayLeagueData.GoalsScored += result.AwayGoals();
                awayLeagueData.GoalsConceded += result.HomeGoals();
                awayLeagueData.GamesPlayed++;

                homeGoals += result.HomeGoals();
                awayGoals += result.AwayGoals();
                gamesPlayed++;
            }

            var averageGoalsScored = league.Values.Sum(l => l.GoalsScored) / 20m;
            Console.WriteLine("Average goals scored: {0}", averageGoalsScored);

            var averageGoalsConceded = league.Values.Sum(l => l.GoalsConceded) / 20m;
            Console.WriteLine("Average goals conceded: {0}", averageGoalsConceded);

            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Team\tGames\tFor\tAgainst\tAttack\tDefence\r\n");

            foreach (var key in league.Keys)
            {
                stringBuilder.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\r\n",
                    key,
                    league[key].GamesPlayed,
                    league[key].GoalsScored,
                    league[key].GoalsConceded,
                    (league[key].GoalsScored / averageGoalsScored).ToString("F04"),
                    (league[key].GoalsConceded / averageGoalsConceded).ToString("F04"));
            }

            stringBuilder.AppendFormat("Average Home Goals\t{0}\r\n", (homeGoals / Convert.ToDecimal(results.Count())).ToString("F04"));
            stringBuilder.AppendFormat("Average Away Goals\t{0}\r\n", (awayGoals / Convert.ToDecimal(results.Count())).ToString("F04"));
            stringBuilder.AppendFormat("Total Home Goals\t{0}\r\n", (homeGoals).ToString("F04"));
            stringBuilder.AppendFormat("Total Away Goals\t{0}\r\n", (awayGoals).ToString("F04"));
            stringBuilder.AppendFormat("Games Played\t{0}", gamesPlayed);

            Console.Write(stringBuilder.ToString());

            Console.ReadKey();
        }
    }

    public class LeagueData
    {
        public int GoalsScored { get; set; }

        public int GoalsConceded { get; set; }

        public int GamesPlayed { get; set; }
    }
}
