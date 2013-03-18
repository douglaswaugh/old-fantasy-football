using System.IO;

namespace AlgorithmFinder.Data
{
    public interface IStreamer
    {
        StreamReader GetStream();
    }
}