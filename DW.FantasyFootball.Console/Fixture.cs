using System;

namespace DW.FantasyFootball.Console
{
    public class Fixture
    {
        public bool Played;
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime Date { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
    }
}