using System;

namespace AlgorithmFinder.Application
{
    public interface ResultsProvider
    {
        Results GetResultsBefore(DateTime before);

        Fixtures GetFixturesAfter(DateTime date);

        Fixtures GetFixturesAfter(DateTime predictAfter, int teamId);
    }
}