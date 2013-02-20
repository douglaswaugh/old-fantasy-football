using NUnit.Framework;

namespace DW.FantasyFootball.Domain.UnitTests
{
    [TestFixture]
    public class SavedResultStoreTest
    {
        [SetUp]
        public void SetUp()
        {
            string gamesweek = @"{""completed"":true,""fixtures"":[{""awayGoals"":0,""awayTeam"":{""name"":""Sunderland""},""date"":""\/Date(1313676000000+0100)\/"",""homeGoals"":0,""homeTeam"":{""name"":""Arsenal""},""played"":true},{""awayGoals"":0,""awayTeam"":{""name"":""Norwich""},""date"":""\/Date(1313676000000+0100)\/"",""homeGoals"":5,""homeTeam"":{""name"":""Fulham""},""played"":true},{""awayGoals"":5,""awayTeam"":{""name"":""Swansea""},""date"":""\/Date(1313676000000+0100)\/"",""homeGoals"":0,""homeTeam"":{""name"":""QPR""},""played"":true},{""awayGoals"":1,""awayTeam"":{""name"":""Stoke City""},""date"":""\/Date(1313676000000+0100)\/"",""homeGoals"":1,""homeTeam"":{""name"":""Reading""},""played"":true},{""awayGoals"":0,""awayTeam"":{""name"":""Liverpool""},""date"":""\/Date(1313676000000+0100)\/"",""homeGoals"":3,""homeTeam"":{""name"":""West Brom""},""played"":true},{""awayGoals"":0,""awayTeam"":{""name"":""Aston Villa""},""date"":""\/Date(1313676000000+0100)\/"",""homeGoals"":1,""homeTeam"":{""name"":""West Ham""},""played"":true},{""awayGoals"":1,""awayTeam"":{""name"":""Tottenham""},""date"":""\/Date(1313685000000+0100)\/"",""homeGoals"":2,""homeTeam"":{""name"":""Newcastle""},""played"":true},{""awayGoals"":2,""awayTeam"":{""name"":""Chelsea""},""date"":""\/Date(1313757000000+0100)\/"",""homeGoals"":0,""homeTeam"":{""name"":""Wigan""},""played"":true},{""awayGoals"":2,""awayTeam"":{""name"":""Southampton""},""date"":""\/Date(1313766000000+0100)\/"",""homeGoals"":3,""homeTeam"":{""name"":""Man City""},""played"":true},{""awayGoals"":0,""awayTeam"":{""name"":""Man Utd""},""date"":""\/Date(1313866800000+0100)\/"",""homeGoals"":1,""homeTeam"":{""name"":""Everton""},""played"":true},{""awayGoals"":2,""awayTeam"":{""name"":""Reading""},""date"":""\/Date(1314038700000+0100)\/"",""homeGoals"":4,""homeTeam"":{""name"":""Chelsea""},""played"":true}],""started"":true}";
            

        }

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