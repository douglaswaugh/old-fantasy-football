namespace AlgorithmFinder.Application
{
    public interface IResultParser
    {
        Result ParseLine(string rawResult);
    }
}