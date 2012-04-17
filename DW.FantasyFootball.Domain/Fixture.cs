using System;
using System.Runtime.Serialization;

namespace DW.FantasyFootball.Domain
{
    [DataContract]
    public class Fixture
    {
        [DataMember(Name = "played")]
        public bool Played { get; set; }

        [DataMember(Name = "homeTeam")]
        public Team HomeTeam { get; set; }

        [DataMember(Name = "awayTeam")]
        public Team AwayTeam { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "homeGoals")]
        public int HomeGoals { get; set; }

        [DataMember(Name = "awayGoals")]
        public int AwayGoals { get; set; }

        public override string ToString()
        {
            return string.Format("HomeTeam: {0}, AwayTeam: {1}, Date: {2}", HomeTeam, AwayTeam, Date);
        }
    }
}