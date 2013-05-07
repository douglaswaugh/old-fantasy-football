using System;
using System.Linq;

namespace AlgorithmFinder.Application
{
    public class PointsPredictor
    {
        private readonly ResultsProvider _fileResultsProvider;
        private readonly TeamProvider _teamProvider;
        private readonly ProbabilityCalculator _probabilityCalculator;


        public PointsPredictor(ResultsProvider fileResultsProvider, TeamProvider teamProvider, ProbabilityCalculator probabilityCalculator)
        {
            _fileResultsProvider = fileResultsProvider;
            _teamProvider = teamProvider;
            _probabilityCalculator = probabilityCalculator;
        }

        public decimal GetPointsFor(Team team, DateTime predictAfter, int playerId)
        {
            #region getting data and stuff
            var fixtures = _fileResultsProvider.GetFixturesAfter(predictAfter, team);
            var results = _fileResultsProvider.GetResultsBefore(predictAfter);
            var populatedTeam = _teamProvider.PopulateTeam(team);
            var player = populatedTeam.GetPlayer(playerId);
            #endregion

            /*#region actual domain stuff
            var prediction = fixtures.First().Predict(results, _probabilityCalculator);
            var expectedPointsFor = fixtures.First().ExpectedPointsFor(player, team, results, prediction);
            #endregion*/

            var expectedPointsCalculator = new ExpectedPointsCalculator(results);
            var expectedPoints = expectedPointsCalculator.GetPointsFor(player, team, fixtures.First());

            return expectedPoints;
        }
    }
}