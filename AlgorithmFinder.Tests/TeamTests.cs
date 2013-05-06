using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class TeamTests
    {
        [Test]
        public void Should_calculate_goals_ratio_as_zero_if_player_has_scored_no_goals()
        {
            var team = new Team(20);

            var player = new Player(508, "Figueroa", new DefenderPointsCalculator());

            player.AddPlayerFixture(new PlayerFixture(0, 0, 0));

            team.AddPlayer(player);

            var goalsRatio = team.GoalsRatioFor(player);

            Assert.That(goalsRatio, Is.EqualTo(0));
        }
    }
}