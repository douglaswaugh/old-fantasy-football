namespace AlgorithmFinder.Application
{
    public class PlayerFixture
    {
        private readonly int _saves;
        private readonly int _bonus;
        private readonly int _goals;

        public PlayerFixture(int saves, int bonus, int goals)
        {
            _saves = saves;
            _bonus = bonus;
            _goals = goals;
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
    }
}