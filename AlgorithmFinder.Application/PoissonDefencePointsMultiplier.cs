using System;
using MathNet.Numerics.Distributions;

namespace AlgorithmFinder.Application
{
    public class PoissonDefencePointsMultiplier : DefencePointsMultiplier
    {
        private readonly Poisson _poissonDistribution;

        public PoissonDefencePointsMultiplier(decimal expectedGoals)
        {
            _poissonDistribution = new Poisson(Convert.ToDouble(expectedGoals));
        }

        public decimal CleanSheet
        {
            get { return Convert.ToDecimal(_poissonDistribution.Probability(0)); }
        }

        public decimal ConcedeTwoOrThree
        {
            get { return Convert.ToDecimal((_poissonDistribution.Probability(2) + _poissonDistribution.Probability(3))); }
        }

        public decimal ConcedeFourOrFive
        {
            get { return Convert.ToDecimal((_poissonDistribution.Probability(4) + _poissonDistribution.Probability(5))); }
        }
    }
}