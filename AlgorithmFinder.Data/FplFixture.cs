using System;
using System.Runtime.Serialization;

namespace AlgorithmFinder.Data
{
    [DataContract]
    public class FplFixture
    {
        [DataMember(Name = "awayGoals")]
        public int AwayGoals { get; private set; }

        [DataMember(Name = "awayTeam")]
        public FplTeam AwayTeam { get; private set; }

        [DataMember(Name = "homeGoals")]
        public int HomeGoals { get; private set; }

        [DataMember(Name = "homeTeam")]
        public FplTeam HomeTeam { get; private set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; private set; }
    }
}