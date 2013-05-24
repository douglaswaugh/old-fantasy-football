using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AlgorithmFinder.Application;
using AlgorithmFinder.Data;

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

            var parser = new CsvFileFixtureParser();
            var results = new Results(new List<Fixture>());
            var league = new Dictionary<string, LeagueData>();
            int homeGoals = 0;
            int awayGoals = 0;
            int gamesPlayed = 0;

            using (var reader = new StreamReader(stream))
            {
                reader.ReadLine();
                string rawResult;
                while ((rawResult = reader.ReadLine()) != null)
                {
                    results.Add(parser.ParseFixtre(rawResult));
                    var cells = rawResult.Split(',');

                    var homeTeam = new Team(cells[0]);
                    var awayTeam = new Team(cells[1]);
                    var matchDate = DateTime.Parse(cells[2]);
                    var score = new Score(Int32.Parse(cells[3]), Int32.Parse(cells[4]));

                    if (!league.ContainsKey(homeTeam.Name))
                    {
                        league.Add(homeTeam.Name, new LeagueData());
                    }
                    if (!league.ContainsKey(awayTeam.Name))
                    {
                        league.Add(awayTeam.Name, new LeagueData());
                    }

                    var homeLeagueData = league[homeTeam.Name];
                    homeLeagueData.GoalsScored += score.HomeGoals;
                    homeLeagueData.GoalsConceded += score.AwayGoals;
                    homeLeagueData.GamesPlayed++;

                    var awayLeagueData = league[awayTeam.Name];
                    awayLeagueData.GoalsScored += score.AwayGoals;
                    awayLeagueData.GoalsConceded += score.HomeGoals;
                    awayLeagueData.GamesPlayed++;

                    homeGoals += score.HomeGoals;
                    awayGoals += score.AwayGoals;
                    gamesPlayed++;
                }
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
