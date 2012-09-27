using NUnit.Framework;

namespace DW.FantasyFootball.Domain.UnitTests
{
    [TestFixture]
    public class FixtureListTest
    {
        [Test]
        public void FixturesForGamesweekOne2012()
        {
            FixtureList fixtureList = FixtureList.For(1, 1, 2012);
        }

        [Test]
        public void FixturesForGamesweeksOneAndTwo2012()
        {
            
        }

        [Test]
        public void FixturesForGamesweeksThirtyEight2011And2012()
        {
            
        }

        [Test]
        public void UpdateFixturesFromServer()
        {
            
        }

        // fixtures between gw 1 and gw 2
        // fixtures between two dates?

    }
}
