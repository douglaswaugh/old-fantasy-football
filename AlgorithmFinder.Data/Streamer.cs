using System.IO;

namespace AlgorithmFinder.Data
{
    public interface Streamer
    {
        StreamReader GetStreamReaderFor(string filePath);
    }
}