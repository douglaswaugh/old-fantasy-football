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

            var deserialiser = Substitute.For<PlayerDeserialiser>();
            deserialiser.Deserialise("playerData")
                .Returns(new Player(508, "Al Habsi", new GoalkeeperPointsCalculator()));

            var fileTeamProvider = new FileTeamProvider(streamer, deserialiser, "C:\\filePath", new Dictionary<int,List<string>> {{ 20, new List<string> { "508" }}});

            var team = fileTeamProvider.GetTeam(20);

            var alHabsi = new Player(508, "Al Habsi", new GoalkeeperPointsCalculator());

            Assert.That(team.GetPlayer(508), Is.EqualTo(alHabsi));
        }
    }
}