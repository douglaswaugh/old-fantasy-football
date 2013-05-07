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

        [SetUp]
        public void SetUp()
        {
            _scoredNone = new PlayerFixture(0, 0, 0);
            _scoredOne = new PlayerFixture(0, 0, 1);
            _wigan = new Team("Wigan");
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

        private Player Kone(PlayerFixture playerFixture)
        {
            var fixtureHistory = new FixtureHistory();

            fixtureHistory.Add(playerFixture);

            return new Player(524, "Kone", new ForwardPointsCalculator(), fixtureHistory);
        }

        private Player Figueroa(PlayerFixture playerFixture)
        {
            var fixtureHistory = new FixtureHistory();

            fixtureHistory.Add(playerFixture);

            return new Player(508, "Figueroa", new DefenderPointsCalculator(), fixtureHistory);
        }
    }
}