using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DW.FantasyFootball.Domain.DataContracts
{
    [DataContract]
    public class Gamesweek
    {
        [DataMember(Name = "fixtures")]
        public List<Fixture> Fixtures { get; set; }

        [DataMember(Name = "completed")]
        public bool Completed { get; set; }

        [DataMember(Name = "started")]
        public bool Started { get; set; }
    }
}