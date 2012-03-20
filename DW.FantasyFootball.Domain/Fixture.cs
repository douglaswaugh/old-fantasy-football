using System;

namespace DW.FantasyFootball.Domain
{
    public class Fixture
    {
        public bool Played;
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime Date { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

        public override string ToString()
        {
            return string.Format("HomeTeam: {0}, AwayTeam: {1}, Date: {2}", HomeTeam, AwayTeam, Date);
        }
    }
}