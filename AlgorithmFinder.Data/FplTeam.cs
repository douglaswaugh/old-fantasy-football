using System.Runtime.Serialization;

namespace AlgorithmFinder.Data
{
    [DataContract]
    public class FplTeam
    {
        [DataMember(Name = "name")]
        public string Name { get; private set; }

    }
}