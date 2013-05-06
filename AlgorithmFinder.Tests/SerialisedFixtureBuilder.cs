namespace AlgorithmFinder.Tests
{
    public class SerialisedFixtureBuilder
    {
        private const string SerialisedFixtureFormat = @"[""03 Nov 15:00"", 10, ""TOT(A) 1-0"", 90, {0}, 0, 1, 0, 0, 0, 0, 0, 0, 5, 0, 20, -2137, 50, 7]";

        private int _goals;

        public SerialisedFixtureBuilder WithGoals(int goals)
        {
            _goals = goals;
            return this;
        }

        public string Build()
        {
            return string.Format(SerialisedFixtureFormat, _goals);
        }
    }
}