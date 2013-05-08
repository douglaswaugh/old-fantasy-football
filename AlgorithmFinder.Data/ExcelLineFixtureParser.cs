using System;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public class ExcelLineFixtureParser : FixtureParser
    {
        public Fixture ParseLine(string rawResult)
        {
            var cells = rawResult.Split(',');
            
            var homeTeam = new Team(cells[0]);
            var awayTeam = new Team(cells[1]);
            var matchDate = DateTime.Parse(cells[2]);
            var score = new Score(Int32.Parse(cells[3]), Int32.Parse(cells[4]));
            
            return new Fixture(
                homeTeam,
                awayTeam,
                matchDate,
                score);
        }

        private int IdForTeam(string teamName)
        {
            switch(teamName)
            {

                case "Reading":
                    return 15;
                case "Tottenham":
                    return 18;
                case "Wigan":
                    return 19;
                case "Wolves":
                    return 20;
                default:
                    return 0;
            }
        }
    }
}