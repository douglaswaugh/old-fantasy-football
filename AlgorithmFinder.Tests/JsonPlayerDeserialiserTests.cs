using AlgorithmFinder.Application;
using AlgorithmFinder.Data;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class JsonPlayerDeserialiserTests
    {
        [Test]
        public void Deserialized_fixture_history_should_contain_bonus()
        {
            var player = new SerialisedPlayerBuilder()
                .WithId(501)
                .WithName("Al Habsi")
                .WithFixture(
                    new SerialisedFixtureBuilder()
                        .WithBonus(3)
                    .Build())
                .WithFixture(
                    new SerialisedFixtureBuilder()
                        .WithBonus(5)
                    .Build())
                .Build();

            var alHabsi = Deserialize(player);

            Assert.That(alHabsi.Bonus, Is.EqualTo(4m));
        }

        [Test]
        public void Deserialized_fixture_history_should_contain_saves()
        {
            var player = new SerialisedPlayerBuilder()
                .WithId(501)
                .WithName("Al Habsi")
                .WithFixture(
                    new SerialisedFixtureBuilder()
                        .WithSaves(2)
                    .Build())
                .WithFixture(
                    new SerialisedFixtureBuilder()
                        .WithSaves(5)
                    .Build())
                .Build();

            var deserializedPlayer = Deserialize(player);

            Assert.That(deserializedPlayer.Saves, Is.EqualTo(3.5m));
        }

        [Test]
        public void Deserialised_fixture_history_should_contain_goals_scored()
        {
            var player = new SerialisedPlayerBuilder()
                .WithId(508)
                .WithName("Figueroa")
                .WithFixture(
                    new SerialisedFixtureBuilder()
                        .WithGoals(2)
                    .Build())
            .Build();

            var deserialisedPlayer = Deserialize(player);

            Assert.That(deserialisedPlayer.Goals, Is.EqualTo(2));
        }

        [Test]
        public void Deserialized_fixture_history_should_contain_assists_made()
        {
            var player = new SerialisedPlayerBuilder()
                .WithId(508)
                .WithName("Figueroa")
                .WithFixture(
                    new SerialisedFixtureBuilder()
                        .WithAssists(2)
                    .Build())
                .Build();

            var deserializedPlayer = Deserialize(player);

            Assert.That(deserializedPlayer.Assists, Is.EqualTo(2));
        }

        [Test]
        public void ShouldDeserialiseIdFromFplPlayer()
        {
            var player = new SerialisedPlayerBuilder()
                .WithId(508)
                .Build();

            var alHabsi = Deserialize(player);

            Assert.That(alHabsi.Id, Is.EqualTo(508));
        }

        [Test]
        public void Deserialized_player_should_contain_contain_team()
        {
            var player = new SerialisedPlayerBuilder()
                .WithId(508)
                .Build();

            var alHabsi = Deserialize(player);

            Assert.That(alHabsi.Team, Is.EqualTo(new Team("Wigan")));
        }

        private static Player Deserialize(string player)
        {
            var alHabsi = new JsonPlayerDeserialiser().Deserialise(player, new Team("Wigan"));

            return alHabsi;
        }
    }
}