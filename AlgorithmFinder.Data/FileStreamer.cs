using System.IO;

namespace AlgorithmFinder.Data
{
    public class FileStreamer : Streamer
    {
        public StreamReader GetStreamReaderFor(string filePath)
        {
            return File.OpenText(filePath);
        }
    }
}