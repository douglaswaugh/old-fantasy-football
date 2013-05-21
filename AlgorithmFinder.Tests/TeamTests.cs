using System.Collections.Generic;
using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class TeamTests
    {
        private PlayerFixture _scoredNone;
        private PlayerFixture _scoredOne;
        private Team _wigan;
        private PlayerFixture _assistedNone;
        private PlayerFixture _assistedOne;

        [SetUp]
        public void SetUp()
        {
            _scoredNone = NewPlayerFixture(0, 0, 0, 0);
            _scoredOne = NewPlayerFixture(0, 0, 1, 0);
            _assistedNone = NewPlayerFixture(0, 0, 0, 0);
            _assistedOne = NewPlayerFixture(0, 0, 0, 1);
            _wigan = new Team("Wigan");
        }

        private static PlayerFixture NewPlayerFixture(int saves, int bonus, int goals, int assists)
        {
            return new PlayerFixture(saves, bonus, goals, assists, 0, 0);
        }

        [Test]
        public void Should_calculate_goals_ratio_as_zero_if_player_has_scored_no_goals()
        {
            var figueroa = Figueroa(_scoredNone);

            _wigan.AddPlayer(figueroa);

            var goalsRatio = _wigan.GoalsRatioFor(figueroa);

            Assert.That(goalsRatio, Is.EqualTo(0));
        }

        [Test]
        public void Should_calculate_goals_ratio_of_1_if_all_goals_scored_by_player()
        {
            var figueroa = Figueroa(_scoredOne);

            _wigan.AddPlayer(figueroa);

            var goalsRatio = _wigan.GoalsRatioFor(figueroa);

            Assert.That(goalsRatio, Is.EqualTo(1));
        }

        [Test]
        public void Should_calculate_goals_ratio_of_0_point_5_if_half_of_goals_scored_by_player()
        {
            _wigan.AddPlayer(Kone(_scoredOne));

            var figueroa = Figueroa(_scoredOne);

            _wigan.AddPlayer(figueroa);

            var goalsRatio = _wigan.GoalsRatioFor(figueroa);

            Assert.That(goalsRatio, Is.EqualTo(0.5m));
        }

        [Test]
        public void Should_calculate_assists_ratio_0_if_player_has_made_no_assists()
        {
            Player figueroa = Figueroa(_assistedNone);

            var assistsRatio = _wigan.AssistsRatioFor(figueroa);

            Assert.That(assistsRatio, Is.EqualTo(0m));
        }

        [Test]
        public void Should_calculate_assists_ratio_1_if_all_assists_made_by_player()
        {
            Player figueroa = Figueroa(_assistedOne);

            _wigan.AddPlayer(figueroa);

            var assistsRatio = _wigan.AssistsRatioFor(figueroa);

            Assert.That(assistsRatio, Is.EqualTo(1m));
        }

        [Test]
        public void Should_calculate_assists_ratio_0_point_5_if_half_of_assists_made_by_player()
        {
            _wigan.AddPlayer(Kone(_assistedOne));

            Player figueroa = Figueroa(_assistedOne);

            _wigan.AddPlayer(figueroa);

            var assistsRatio = _wigan.AssistsRatioFor(figueroa);

            Assert.That(assistsRatio, Is.EqualTo(0.5m));
        }

        private Player Kone(PlayerFixture playerFixture)
        {
            var fixtures = new List<PlayerFixture> { playerFixture };

            return new Player(524, "Kone", new ForwardPointsCalculator(), new FixtureHistory(fixtures), _wigan);
        }

        private Player Figueroa(PlayerFixture playerFixture)
        {
            var fixtures = new List<PlayerFixture> { playerFixture };

            return new Player(508, "Figueroa", new DefenderPointsCalculator(), new FixtureHistory(fixtures), _wigan);
        }
    }
}