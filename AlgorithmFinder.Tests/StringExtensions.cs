using System.IO;

namespace AlgorithmFinder.Tests
{
    public static class StringExtensions
    {
        public static StreamReader ToStreamReader(this string @string)
        {
            var stream = new MemoryStream();

            var writer = new StreamWriter(stream);

            writer.Write(@string);

            writer.Flush();

            stream.Position = 0;

            return new StreamReader(stream);
        }
    }
}