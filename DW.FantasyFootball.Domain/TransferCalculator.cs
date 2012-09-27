namespace DW.FantasyFootball.Domain
{
    public class TransferCalculator
    {
        private readonly Results _results;
        private readonly FixtureList _fixtures;
        private readonly Squad _squad;

        public TransferCalculator(Results results, FixtureList fixtures, Squad squad)
        {
            _results = results;
            _fixtures = fixtures;
            _squad = squad;
        }

        public Player PlayerToSell()
        {
            return new Player();
        }

        public Player PlayerToBuy()
        {
            return new Player();
        }
    }
}