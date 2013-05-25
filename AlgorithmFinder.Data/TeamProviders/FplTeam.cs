using System.Runtime.Serialization;

namespace AlgorithmFinder.Data.TeamProviders
{
    [DataContract]
    public class FplTeam
    {
        [DataMember(Name = "name")]
        public string Name { get; private set; }

    }
}