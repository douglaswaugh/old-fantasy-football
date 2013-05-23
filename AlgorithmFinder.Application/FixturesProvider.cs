using System;

namespace AlgorithmFinder.Application
{
    public interface FixturesProvider
    {
        Fixtures GetFixturesAfter(DateTime date);

        Fixtures GetFixturesAfter(DateTime predictAfter, Team team);
    }
}