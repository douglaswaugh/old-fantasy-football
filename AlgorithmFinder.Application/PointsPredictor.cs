using System;
using System.Linq;

namespace AlgorithmFinder.Application
{
    public class PointsPredictor
    {
        private readonly ResultsProvider _resultsProvider;
        private readonly FixturesProvider _fixturesProvider;
        private readonly TeamProvider _teamProvider;

        public PointsPredictor(ResultsProvider resultsProvider, FixturesProvider fixturesProvider, TeamProvider teamProvider)
        {
            _resultsProvider = resultsProvider;
            _fixturesProvider = fixturesProvider;
            _teamProvider = teamProvider;
        }

        public decimal GetPointsFor(Team team, DateTime predictAfter, int playerId)
        {
            var fixtures = _fixturesProvider.GetFixturesAfter(predictAfter, team);
            var results = _resultsProvider.GetResultsBefore(predictAfter);
            var populatedTeam = _teamProvider.PopulateTeam(team);
            var player = populatedTeam.GetPlayer(playerId);
            
            var expectedPointsCalculator = new ExpectedPointsCalculator(results);
            var expectedPoints = expectedPointsCalculator.GetPointsFor(player, fixtures.First());

            return expectedPoints;
        }
    }
}