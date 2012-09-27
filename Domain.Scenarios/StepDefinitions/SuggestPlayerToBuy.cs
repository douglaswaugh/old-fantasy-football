using DW.FantasyFootball.Domain;
using TechTalk.SpecFlow;

namespace Dw.FantasyFootball.Domain.Scenarios.StepDefinitions
{
    [Binding]
    public class SuggestPlayerToBuy
    {
        private Results _results;
        private FixtureList _fixtures;
        private Squad _squad;
        private TransferCalculator _calculator;

        [Given(@"one gamesweek has been played")]
        public void GivenOneGamesweekHasBeenPlayed()
        {
            var resultsStore = new SavedResults();

            var results = new ResultsRepository(resultsStore);

            _results = results.For(1, 2012, 1);
        }

        [Given(@"one gamesweek has yet to be played")]
        public void GivenOneGamesweekHasYetToBePlayed()
        {
            _fixtures = FixtureList.For(2, 2012, 1);
        }

        [Given(@"I have selected a team")]
        public void GivenIHaveSelectedATeam()
        {
            _squad = Squad.For(2, 2012);
        }

        [When(@"I calculate the best transfer")]
        public void WhenICalculateTheBestTransfer()
        {
            _calculator = new TransferCalculator(_results, _fixtures, _squad);
        }

        [Then(@"my worst goalkeeper should be suggested to transfer out")]
        public void ThenMyWorstGoalkeeperShouldBeSuggestedToTransferOut()
        {
            Player toSell = _calculator.PlayerToSell();
        }

        [Then(@"the best goalkeeper should be suggested to transfer in")]
        public void ThenTheBestGoalkeeperShouldBeSuggestedToTransferIn()
        {
            Player toBuy = _calculator.PlayerToBuy();
        }
    }
}