using System.IO;

namespace AlgorithmFinder.Data
{
    public class FileStreamer : IStreamer
    {
        private readonly string _filePath;

        public FileStreamer(string filePath)
        {
            _filePath = filePath;
        }

        public StreamReader GetStream()
        {
            var fileInfo = new FileInfo(_filePath);

            return fileInfo.OpenText();
        }
    }
}