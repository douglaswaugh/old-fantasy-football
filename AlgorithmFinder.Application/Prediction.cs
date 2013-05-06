using System;

namespace AlgorithmFinder.Application
{
    public class Prediction : IPrediction
    {
        private readonly double[][] _probabilities;

        public Prediction(double[][] probabilities)
        {
            _probabilities = probabilities;
        }

        public bool MostLikelyScoreIs(Score score)
        {
            double highestProbability = 0.0;
            var mostLikelyScore = new Score(0, 0);

            for (int homeGoals = 0; homeGoals < 6; homeGoals++)
            {
                for (int awayGoals = 0; awayGoals < 6; awayGoals++)
                {
                    if (_probabilities[homeGoals][awayGoals] > highestProbability)
                    {
                        highestProbability = _probabilities[homeGoals][awayGoals];
                        mostLikelyScore = new Score(homeGoals, awayGoals);
                    }
                }
            }

            return mostLikelyScore.Equals(score);
        }

        public decimal DefencePointsFor()
        {
            return 0m;
        }

        public decimal DefencePointsForHomeTeam()
        {
            var cleanSheetProbability = 0m;
            var goalsConcededProbability = 0m;

            for (int homeGoals = 0; homeGoals < _probabilities.Length; homeGoals++)
            {
                for (int awayGoals = 0; awayGoals < _probabilities[homeGoals].Length; awayGoals++)
                {
                    if (awayGoals == 0)
                    {
                        cleanSheetProbability += Convert.ToDecimal(_probabilities[homeGoals][awayGoals]);   
                    }
                    if (awayGoals > 1)
                    {
                        goalsConcededProbability += Convert.ToDecimal(_probabilities[homeGoals][awayGoals]);
                    }
                }
            }

            return (cleanSheetProbability*4) + (goalsConcededProbability*-1);
        }

        public decimal DefencePointsForAwayTeam()
        {
            var cleanSheetProbability = 0m;
            var goalsConcededProbability = 0m;

            for (int homeGoals = 0; homeGoals < _probabilities.Length; homeGoals++)
            {
                for (int awayGoals = 0; awayGoals < _probabilities[homeGoals].Length; awayGoals++)
                {
                    if (homeGoals == 0)
                    {
                        cleanSheetProbability += Convert.ToDecimal(_probabilities[homeGoals][awayGoals]);
                    }
                    if (homeGoals > 1)
                    {
                        goalsConcededProbability += Convert.ToDecimal(_probabilities[homeGoals][awayGoals]);
                    }
                }
            }

            return (cleanSheetProbability*4) + (goalsConcededProbability*-1);
        }
    }

    public interface IPrediction
    {
        decimal DefencePointsForHomeTeam();
        decimal DefencePointsForAwayTeam();
    }
}