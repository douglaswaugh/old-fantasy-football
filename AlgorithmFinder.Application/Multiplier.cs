namespace AlgorithmFinder.Application
{
    public class Multiplier
    {
        private readonly decimal _cleanSheet;
        private readonly decimal _concedeTwoOrThree;
        private readonly decimal _concedeFourOrFive;

        public Multiplier(decimal cleanSheet, decimal concedeTwoOrThree, decimal concedeFourOrFive)
        {
            _cleanSheet = cleanSheet;
            _concedeTwoOrThree = concedeTwoOrThree;
            _concedeFourOrFive = concedeFourOrFive;
        }

        public decimal CleanSheet
        {
            get { return _cleanSheet; }
        }

        public decimal ConcedeTwoOrThree
        {
            get { return _concedeTwoOrThree; }
        }

        public decimal ConcedeFourOrFive
        {
            get { return _concedeFourOrFive; }
        }
    }
}