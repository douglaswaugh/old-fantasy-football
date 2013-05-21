namespace AlgorithmFinder.Application
{
    public class PlayerFixture
    {
        private readonly int _saves;
        private readonly int _bonus;
        private readonly int _goals;
        private readonly int _assists;
        private readonly int _yellowCards;
        private readonly int _redCards;

        public PlayerFixture(int saves, int bonus, int goals, int assists, int yellowCards)
        {
            _saves = saves;
            _bonus = bonus;
            _goals = goals;
            _assists = assists;
            _yellowCards = yellowCards;
        }

        public PlayerFixture(int saves, int bonus, int goals, int assists, int yellowCards, int redCards)
        {
            _saves = saves;
            _bonus = bonus;
            _goals = goals;
            _assists = assists;
            _yellowCards = yellowCards;
            _redCards = redCards;
        }

        public int Saves
        {
            get { return _saves; }
        }

        public int Bonus
        {
            get { return _bonus; }
        }

        public int Goals
        {
            get { return _goals; }
        }

        public int Assists
        {
            get { return _assists; }
        }

        public int YellowCards
        {
            get { return _yellowCards; }
        }

        public int RedCards
        {
            get { return _redCards; }
        }
    }
}