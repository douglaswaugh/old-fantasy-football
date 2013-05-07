using System;
using MathNet.Numerics.Distributions;

namespace AlgorithmFinder.Application
{
    public class PoissonDefencePointsMultiplier : DefencePointsMultiplier
    {
        public Multiplier Calculate(decimal expectedGoals)
        {
            var poissonDistribution = new Poisson(Convert.ToDouble(expectedGoals));

            var cleanSheetPoints = Convert.ToDecimal(poissonDistribution.Probability(0));

            var conceedTwoOrThreePoints = Convert.ToDecimal((poissonDistribution.Probability(2) + poissonDistribution.Probability(3)));

            var conceedFourOrFivePoints = Convert.ToDecimal((poissonDistribution.Probability(4) + poissonDistribution.Probability(5)));

            return new Multiplier(cleanSheetPoints, conceedTwoOrThreePoints, conceedFourOrFivePoints);
        }
    }
}