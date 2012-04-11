using System;
using MathNet.Numerics.Distributions;

namespace DW.FantasyFootball.Domain
{
    public class StatFixture
    {
        private readonly decimal _goalsFor;
        private readonly decimal _goalsAgainst;

        public StatFixture(decimal goalsFor, decimal goalsAgainst)
        {
            _goalsFor = goalsFor;
            _goalsAgainst = goalsAgainst;
        }

        public decimal GoalsAgainst
        {
            get { return _goalsAgainst; }
        }

        public decimal GoalsFor
        {
            get { return _goalsFor; }
        }

        public double ProbabilityOfCleanSheet
        {
            get
            {
                var poisson = new Poisson(Decimal.ToDouble(_goalsAgainst));

                return poisson.Probability(0);
            }
        }
    }
}