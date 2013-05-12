using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public interface PlayerDeserialiser
    {
        Player Deserialise(string playerData, Team team);
    }
}