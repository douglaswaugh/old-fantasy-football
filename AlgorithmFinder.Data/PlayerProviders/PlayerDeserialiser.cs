using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data.PlayerProviders
{
    public interface PlayerDeserialiser
    {
        Player Deserialise(string playerData, Team team);
    }
}