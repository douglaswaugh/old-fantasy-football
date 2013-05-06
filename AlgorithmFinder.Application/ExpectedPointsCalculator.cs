namespace AlgorithmFinder.Application
{
    public class ExpectedPointsCalculator
    {
        private readonly ExpectedGoalsCalculator _expectedGoalsCalculator;
        private readonly ProbabilityCalculator _probabilityCalculator;

        public ExpectedPointsCalculator(ExpectedGoalsCalculator expectedGoalsCalculator, ProbabilityCalculator probabilityCalculator)
        {
            _expectedGoalsCalculator = expectedGoalsCalculator;
            _probabilityCalculator = probabilityCalculator;
        }

        public decimal GetPointsFor(Player player, Team team, Fixture fixture)
        {
            var expectedGoals = _expectedGoalsCalculator.ExpectedGoalsFor(fixture);

            /*var probabilityMatrix = _probabilityCalculator.GetPrediction(expectedGoals);

            var prediction = new Prediction(probabilityMatrix);

            var defencePoints = prediction.DefencePointsForHomeTeam();

            var bonusPoints = player.FixtureHistory.Bonus;

            var goalPoints = team.GoalsRatioFor(player);

            return defencePoints + bonusPoints + goalPoints;*/

            return 0m;
        }
    }
}