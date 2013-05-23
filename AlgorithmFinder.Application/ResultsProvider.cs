using System;

namespace AlgorithmFinder.Application
{
    public interface ResultsProvider
    {
        Results GetResultsBefore(DateTime date);
    }
}