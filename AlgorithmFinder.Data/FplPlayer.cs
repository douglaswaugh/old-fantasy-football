using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlgorithmFinder.Data
{
    [DataContract]
    public class FplPlayer
    {
        [DataMember(Name = "fixture_history")]
        public Dictionary<string, List<List<string>>> FixtureHistory { get; private set; }

        [DataMember(Name = "id")]
        public int Id { get; private set; }

        [DataMember(Name = "type_name")]
        public string TypeName { get; private set; }
    }
}