using System;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public class ExcelLineFixtureParser : FixtureParser
    {
        public Fixture ParseLine(string rawResult)
        {
            var cells = rawResult.Split(',');
            
            var homeTeam = new Team(cells[0], IdForTeam(cells[0]));
            var awayTeam = new Team(cells[1], IdForTeam(cells[1]));
            var matchDate = DateTime.Parse(cells[2]);
            var score = new Score(Int32.Parse(cells[3]), Int32.Parse(cells[4]));
            var homeShots = new Shots(Int32.Parse(cells[5]));
            var homeShotsOnTarget = new Shots(Int32.Parse(cells[6]));
            var awayShots = new Shots(Int32.Parse(cells[7]));
            var awayShotsOnTarget = new Shots(Int32.Parse(cells[8]));
            var division = new Division(Int32.Parse(cells[9]));
            var season = new Season(Int32.Parse(cells[10]));
            
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
                case "Wigan":
                    return 20;
                case "Wolves":
                    return 19;
                default:
                    return 0;
            }
        }
    }
}