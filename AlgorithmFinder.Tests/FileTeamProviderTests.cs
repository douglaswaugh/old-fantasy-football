using System.Collections.Generic;
using System.IO;
using System.Text;
using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;
using AlgorithmFinder.Data;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class FileTeamProviderTests
    {
        [Test]
        public void PopulateTeam()
        {
            var streamer = Substitute.For<Streamer>();
            streamer.GetStreamReaderFor(@"C:\filePath\508.json")
                .Returns(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes("playerData"))));

            var wigan = new Team("Wigan");

            var deserialiser = Substitute.For<PlayerDeserialiser>();
            deserialiser.Deserialise("playerData", wigan)
                .Returns(new Player(508, "Al Habsi", new GoalkeeperPointsCalculator(), new FixtureHistory(new List<PlayerFixture>()), wigan));
            
            var fileTeamProvider = new FileTeamProvider(streamer, deserialiser, "C:\\filePath", new Dictionary<Team, List<string>> {{ wigan, new List<string> { "508" }}});

            var team = fileTeamProvider.PopulateTeam(wigan);

            var alHabsi = new Player(508, "Al Habsi", new GoalkeeperPointsCalculator(), new FixtureHistory(new List<PlayerFixture>()), wigan);

            Assert.That(team.GetPlayer(508), Is.EqualTo(alHabsi));
        }

        [Test]
        public void Player_should_have_reference_to_team_after_player_has_joined_team()
        {
            var streamer = Substitute.For<Streamer>();
            streamer.GetStreamReaderFor(@"C:\filePath\508.json")
                .Returns(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes("playerData"))));

            var wigan = new Team("Wigan");

            var deserialiser = Substitute.For<PlayerDeserialiser>();
            deserialiser.Deserialise("playerData", wigan)
                .Returns(new Player(508, "Al Habsi", new GoalkeeperPointsCalculator(), new FixtureHistory(new List<PlayerFixture>()), wigan));
            
            var fileTeamProvider = new FileTeamProvider(streamer, deserialiser, "C:\\filePath", new Dictionary<Team, List<string>> {{ wigan, new List<string> { "508" }}});

            var team = fileTeamProvider.PopulateTeam(wigan);

            Assert.That(team.GetPlayer(508).Team, Is.EqualTo(team));
        }
    }
}