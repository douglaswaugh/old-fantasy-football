using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AlgorithmFinder.Data
{
    [DataContract]
    public class FplFixtures
    {
        [DataMember(Name = "fixtures")]
        public IEnumerable<FplFixture> Fixtures { get; private set; }
    }
}