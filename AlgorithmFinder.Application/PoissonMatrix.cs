using System;
using MathNet.Numerics.Distributions;

namespace AlgorithmFinder.Application
{
    public class PoissonMatrix : ProbabilityCalculator
    {
        private readonly double _expectedHomeGoals;
        private readonly double _expectedAwayGoals;
        private readonly double[][] _matrix = new double[6][];

        /*public PoissonMatrix(decimal expectedHomeGoals, decimal expectedAwayGoals)
        {
            _expectedHomeGoals = Convert.ToDouble(expectedHomeGoals);
            _expectedAwayGoals = Convert.ToDouble(expectedAwayGoals);

            FillMatrix();
        }*/

        /*public Score MostLikelyScore()
        {
            double highestProbability = 0.0;
            var score = new Score(0, 0);

            for (int homeGoals = 0; homeGoals < 6; homeGoals++)
            {
                for (int awayGoals = 0; awayGoals < 6; awayGoals++)
                {
                    if (_matrix[homeGoals][awayGoals] > highestProbability)
                    {
                        highestProbability = _matrix[homeGoals][awayGoals];
                        score = new Score(homeGoals, awayGoals);
                    }
                }
            }

            return score;
        }*/

        public double[][] GetPrediction(ExpectedGoals expectedGoals)
        {
            var matrix = new double[6][];

            for (int i = 0; i < 6; i++)
            {
                matrix[i] = new double[6];
                for (int j = 0; j < 6; j++)
                {
                    var homeGoalsPoisson = new Poisson(Convert.ToDouble(expectedGoals.Home));
                    var awayGoalsPoisson = new Poisson(Convert.ToDouble(expectedGoals.Away));
                    matrix[i][j] = homeGoalsPoisson.Probability(i)*awayGoalsPoisson.Probability(j);
                }
            }

            return matrix;
        }

        /*private void FillMatrix()
        {
            for (int i = 0; i < 6; i++)
            {
                _matrix[i] = new double[6];
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var homeGoalsPoisson = new Poisson(_expectedHomeGoals);
                    var awayGoalsPoisson = new Poisson(_expectedAwayGoals);
                    _matrix[i][j] = homeGoalsPoisson.Probability(i)*awayGoalsPoisson.Probability(j);
                }
            }
        }*/
    }
}