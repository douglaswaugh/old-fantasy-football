namespace AlgorithmFinder.Tests
{
    public class SerialisedFixtureBuilder
    {
        private const string SerialisedFixtureFormat = @"[""03 Nov 15:00"", 10, ""TOT(A) 1-0"", 90, {0}, {1}, 1, 0, 0, 0, 0, 0, 0, {2}, {3}, 20, -2137, 50, 7]";
        private int _goals;
        private int _assists;
        private int _saves;
        private int _bonus;

        public SerialisedFixtureBuilder WithGoals(int goals)
        {
            _goals = goals;
            return this;
        }

        public SerialisedFixtureBuilder WithAssists(int assists)
        {
            _assists = assists;
            return this;
        }

        public SerialisedFixtureBuilder WithSaves(int saves)
        {
            _saves = saves;
            return this;
        }

        public SerialisedFixtureBuilder WithBonus(int bonus)
        {
            _bonus = bonus;
            return this;
        }

        public string Build()
        {
            return string.Format(SerialisedFixtureFormat, _goals, _assists, _saves, _bonus);
        }
    }
}