namespace DW.FantasyFootball.Domain
{
    public class FixtureListPrinter
    {
        private readonly FixtureList _fixtureList;

        public FixtureListPrinter(FixtureList fixtureList)
        {
            _fixtureList = fixtureList;
        }

        public void Print()
        {
            foreach (var gamesweek in _fixtureList)
            {
                var fixturePrinter = new GamesweekPrinter(gamesweek);

                fixturePrinter.Print();
            }
        }
    }
}