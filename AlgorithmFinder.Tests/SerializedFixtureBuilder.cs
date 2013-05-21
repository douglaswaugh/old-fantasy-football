namespace AlgorithmFinder.Tests
{
    public class SerializedFixtureBuilder
    {
        private const string SerialisedFixtureFormat = @"[""03 Nov 15:00"", 10, ""TOT(A) 1-0"", 90, {0}, {1}, 1, 0, 0, 0, 0, {4}, {5}, {2}, {3}, 20, -2137, 50, 7]";
        private int _goals;
        private int _assists;
        private int _saves;
        private int _bonus;
        private int _yellowCards;
        private int _redCards;

        public SerializedFixtureBuilder WithGoals(int goals)
        {
            _goals = goals;
            return this;
        }

        public SerializedFixtureBuilder WithAssists(int assists)
        {
            _assists = assists;
            return this;
        }

        public SerializedFixtureBuilder WithSaves(int saves)
        {
            _saves = saves;
            return this;
        }

        public SerializedFixtureBuilder WithBonus(int bonus)
        {
            _bonus = bonus;
            return this;
        }

        public SerializedFixtureBuilder WithYellowCards(int yellowCards)
        {
            _yellowCards = yellowCards;
            return this;
        }

        public SerializedFixtureBuilder WithRedCards(int redCards)
        {
            _redCards = redCards;
            return this;
        }

        public string Build()
        {
            return string.Format(SerialisedFixtureFormat, _goals, _assists, _saves, _bonus, _yellowCards, _redCards);
        }
    }
}