using System;

namespace AlgorithmFinder.Application
{
    public interface ResultsProvider
    {
        Results GetResultsBefore(DateTime date);

        Fixtures GetFixturesAfter(DateTime date);

        Fixtures GetFixturesAfter(DateTime predictAfter, Team team);
    }
}