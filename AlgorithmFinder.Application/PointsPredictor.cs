using System;
using System.Linq;

namespace AlgorithmFinder.Application
{
    public class PointsPredictor
    {
        private readonly ResultsProvider _fileResultsProvider;
        private readonly TeamProvider _teamProvider;

        public PointsPredictor(ResultsProvider fileResultsProvider, TeamProvider teamProvider)
        {
            _fileResultsProvider = fileResultsProvider;
            _teamProvider = teamProvider;
        }

        public decimal GetPointsFor(Team team, DateTime predictAfter, int playerId)
        {
            var fixtures = _fileResultsProvider.GetFixturesAfter(predictAfter, team);
            var results = _fileResultsProvider.GetResultsBefore(predictAfter);
            var populatedTeam = _teamProvider.PopulateTeam(team);
            var player = populatedTeam.GetPlayer(playerId);
            
            var expectedPointsCalculator = new ExpectedPointsCalculator(results);
            var expectedPoints = expectedPointsCalculator.GetPointsFor(player, team, fixtures.First());

            return expectedPoints;
        }
    }
}