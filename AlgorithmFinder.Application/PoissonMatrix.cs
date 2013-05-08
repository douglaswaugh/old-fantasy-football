using System;
using MathNet.Numerics.Distributions;

namespace AlgorithmFinder.Application
{
    public class PoissonMatrix : ProbabilityCalculator
    {
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
    }
}