using NUnit.Framework;
using Rhino.Mocks;

namespace DW.FantasyFootball.Domain.UnitTests
{
    /*
     * retrieve a fixture from a saved file
     * if fixture is not saved retrieve a fixture from the website and save fixture
     */

    [TestFixture]
    public class ResultsRespositoryTest
    {
        [Test]
        public void WhenASavedResultDoesNotExist()
        {
            var savedResults = MockRepository.GenerateMock<IResultsStore>();

            savedResults.Expect(s => s.Exists(1, 2012, 1)).Return(false);
            
            var resultsRepository = new ResultsRepository(savedResults);

            resultsRepository.For(1, 2012, 1);

            savedResults.VerifyAllExpectations();
        }

        [Test]
        public void WhenASavedResultExists()
        {
            var savedResults = MockRepository.GenerateMock<IResultsStore>();

            savedResults.Expect(s => s.Exists(1, 2012, 1)).Return(true);

            savedResults.Expect(s => s.For(1, 2012, 1)).Return(new Results());

            var resultsRepository = new ResultsRepository(savedResults);

            resultsRepository.For(1, 2012, 1);

            savedResults.VerifyAllExpectations();
        }

        [Test]
        [Ignore]
        public void ShouldReturnCorrectSavedResult()
        {
            var expectedResults = new Results
            {
                new Result(new Team("arsenal"), new Team("sunderland"), 0, 0),
                new Result(new Team("fulham"), new Team("norwich"), 5, 0),
                new Result(new Team("qpr"), new Team("swansea"), 0, 5),
                new Result(new Team("reading"), new Team("stoke city"), 1, 1),
                new Result(new Team("west brom"), new Team("liverpool"), 3, 0),
                new Result(new Team("west ham"), new Team("aston villa"), 1, 0),
                new Result(new Team("newcastle"), new Team("tottenham"), 2, 1),
                new Result(new Team("wigan"), new Team("chelsea"), 0, 2),
                new Result(new Team("man city"), new Team("southampton"), 3, 2),
                new Result(new Team("everton"), new Team("man united"), 1, 0),
                new Result(new Team("chelsea"), new Team("reading"), 4, 2)
            };
        }
    }
}
