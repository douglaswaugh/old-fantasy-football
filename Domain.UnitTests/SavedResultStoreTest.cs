using NUnit.Framework;

namespace DW.FantasyFootball.Domain.UnitTests
{
    [TestFixture]
    public class SavedResultStoreTest
    {
        [Test]
        public void Should_return_false_if_single_gamesweek_not_saved()
        {
            IResultsStore savedResults = new SavedResults();

            bool gamesweekSaved = savedResults.Exists(1, 2012);

            Assert.That(gamesweekSaved, Is.False);
        }

        [Test]
        public void Should_return_true_if_single_gamesweek_saved()
        {
            IResultsStore savedResults = new SavedResults();

            bool gamesweekSaved = savedResults.Exists(2, 2012);

            Assert.That(gamesweekSaved, Is.True);
        }
    }
}