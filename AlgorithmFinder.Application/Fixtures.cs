using System.Collections;
using System.Collections.Generic;

namespace AlgorithmFinder.Application
{
    public class Fixtures : IEnumerable<Fixture>
    {
        private readonly List<Fixture> _fixtures = new List<Fixture>();

        public IEnumerator<Fixture> GetEnumerator()
        {
            return _fixtures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void GetPrediction(IResults results, Prediction prediction)
        {
            foreach (var fixture in _fixtures)
            {
                var expectedHomeGoals = results.ExpectedHomeGoals(fixture.HomeTeam, fixture.AwayTeam);
                var expectedAwayGoals = results.ExpectedAwayGoals(fixture.HomeTeam, fixture.AwayTeam);

                fixture.PredictScore(prediction, new PoissonMatirx(expectedHomeGoals, expectedAwayGoals));
            }
        }
    }
}