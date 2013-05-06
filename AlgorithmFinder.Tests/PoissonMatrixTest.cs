using System;
using AlgorithmFinder.Application;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class PoissonMatrixTest
    {
        [Test]
        public void ShouldCalculateProbabilities()
        {
            var expectedHomeGoals = 1.92m;
            var expectedAwayGoals = 2.88m;

            var poissonMatrix = new PoissonMatrix();

            var probabilities = poissonMatrix.GetPrediction(new ExpectedGoals(expectedHomeGoals, expectedAwayGoals));

            double tolerance = 1.0 / Math.Pow(10, 9);

            Assert.That(probabilities, Is.EqualTo(PredictionFor192HomeGoals288AwayGoals()).Within(tolerance));
        }

        private static double[][] PredictionFor192HomeGoals288AwayGoals()
        {
            var flatProbabilities = new double[6][]
            {
                new double[6]
                {
                    0.008229747d,
                    0.023701672d,
                    0.034130407d,
                    0.032765191d,
                    0.023590937d,
                    0.01358838d   
                },
                new double[6]
                {
                    0.015801114d,
                    0.045507209d,
                    0.065530381d,
                    0.062909166d,
                    0.0452946d,
                    0.026089689d
                },
                new double[6]{
                    0.01516907d,
                    0.043686921d,
                    0.062909166d,
                    0.060392799d,
                    0.043482816d,
                    0.025046102d
                },
                new double[6]{
                    0.009708205d,
                    0.027959629d,
                    0.040261866d,
                    0.038651392d,
                    0.027829002d,
                    0.016029505d
                },
                new double[6]{
                    0.004659938d,
                    0.013420622d,
                    0.019325696d,
                    0.018552668d,
                    0.013357921d,
                    0.007694162d,
                },
                new double[6]{
                    0.001789416d,
                    0.005153519d,
                    0.007421067d,
                    0.007124225d,
                    0.005129442d,
                    0.002954558d
                }
            };

            return flatProbabilities;
        }
    }
}
