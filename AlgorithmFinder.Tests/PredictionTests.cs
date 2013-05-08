using AlgorithmFinder.Application;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class PredictionTests
    {
        [Test]
        public void ShouldCalcuateHomeCleanSheet()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.2},
                new[] {0.4}
            });

            var homeDefencePoints = prediction.DefencePointsForHomeTeam();

            Assert.That(homeDefencePoints, Is.EqualTo(2.4m));
        }

        [Test]
        public void ShouldCalculateNoReductionForOneGoalConcededByHomeTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.2, 0.3},
                new[] {0.4, 0.1}
            });

            var homeDefencePoints = prediction.DefencePointsForHomeTeam();

            Assert.That(homeDefencePoints, Is.EqualTo(2.4m));
        }

        [Test]
        public void ShouldCalculateReductionForTwoGoalsConcededByHomeTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.1, 0.1, 0.2},
                new[] {0.2, 0.1, 0.1},
                new[] {0.05, 0.05, 0.1}
            });
            var homeDefencePoints = prediction.DefencePointsForHomeTeam();
            Assert.That(homeDefencePoints, Is.EqualTo(1m));
        }

        [Test]
        public void ShouldCalculateReductionForThreeGoalsConcededByHomeTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.1, 0.1, 0.2, 0.3},
                new[] {0.2, 0.1, 0.1, 0.2},
                new[] {0.05, 0.05, 0.1, 0.2}
            });
            var homeDefencePoints = prediction.DefencePointsForHomeTeam();
            Assert.That(homeDefencePoints, Is.EqualTo(0.3m));
        }

        [Test]
        public void ShouldCalculateReductionForFourGoalsConcededByHomeTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.1, 0.1, 0.2, 0.3, 0.2},
                new[] {0.2, 0.1, 0.1, 0.2, 0.1},
                new[] {0.05, 0.05, 0.1, 0.2, 0.1}
            });
            var homeDefencePoints = prediction.DefencePointsForHomeTeam();

            Assert.That(homeDefencePoints, Is.EqualTo(-0.1m));
        }

        [Test]
        public void ShouldCalculateReductionForFiveGoalsConcededByHomeTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.1, 0.1, 0.2, 0.3, 0.2, 0.4},
                new[] {0.2, 0.1, 0.1, 0.2, 0.1, 0.2},
                new[] {0.05, 0.05, 0.1, 0.2, 0.1, 0.3}
            });
            var homeDefencePoints = prediction.DefencePointsForHomeTeam();

            Assert.That(homeDefencePoints, Is.EqualTo(-1m));
        }

        [Test]
        public void ShouldCalcuateHomeTeamDefencePointsForRealWorldData()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.008229747, 0.023701672, 0.034130407, 0.032765191, 0.023590937, 0.01358838 },
                new[] {0.015801114, 0.045507209, 0.065530381, 0.062909166, 0.0452946  , 0.026089689 },
                new[] {0.01516907,  0.043686921, 0.062909166, 0.060392799, 0.043482816, 0.025046102 },
                new[] {0.009708205, 0.027959629, 0.040261866, 0.038651392, 0.027829002, 0.016029505 },
                new[] {0.004659938, 0.013420622, 0.019325696, 0.018552668, 0.013357921, 0.007694162 },
                new[] {0.001789416, 0.005153519, 0.007421067, 0.007124225, 0.005129442, 0.002954558 }
            });
            var homeDefencePoints = prediction.DefencePointsForHomeTeam();
            Assert.That(homeDefencePoints, Is.EqualTo(-0.47863).Within(0.00001m));
        }

        [Test]
        public void ShouldCalcuateAwayCleanSheet()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.2, 0.3}
            });

            var awayDefencePoints = prediction.DefencePointsForAwayTeam();

            Assert.That(awayDefencePoints, Is.EqualTo(2m));
        }

        [Test]
        public void ShouldCalculateNoReductionForOneGoalConcededByAwayTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.2, 0.3},
                new[] {0.4, 0.1}
            });

            var awayDefencePoints = prediction.DefencePointsForAwayTeam();

            Assert.That(awayDefencePoints, Is.EqualTo(2m));
        }

        [Test]
        public void ShouldCalculateReductionForTwoGoalsConcededByAwayTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.2, 0.3}, 
                new[] {0.4, 0.1}, 
                new[] {0.05, 0.05 }
            });
            var awayDefencePoints = prediction.DefencePointsForAwayTeam();
            Assert.That(awayDefencePoints, Is.EqualTo(1.9m));
        }

        [Test]
        public void ShouldCalculateReductionForThreeGoalsConcededByAwayTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.2, 0.3}, 
                new[] {0.4, 0.1}, 
                new[] {0.05, 0.05 },
                new[] {0.2, 0.4}
            });
            var awayDefencePoints = prediction.DefencePointsForAwayTeam();
            Assert.That(awayDefencePoints, Is.EqualTo(1.3m));
        }

        [Test]
        public void ShouldCalculateReductionForFourGoalsConcededByAwayTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.2, 0.3}, 
                new[] {0.4, 0.1}, 
                new[] {0.05, 0.05 },
                new[] {0.2, 0.4},
                new[] {0.1, 0.2}
            });
            var awayDefencePoints = prediction.DefencePointsForAwayTeam();

            Assert.That(awayDefencePoints, Is.EqualTo(1m));
        }

        [Test]
        public void ShouldCalculateReductionForFiveGoalsConcededByAwayTeam()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.2, 0.3}, 
                new[] {0.4, 0.1}, 
                new[] {0.05, 0.05 },
                new[] {0.2, 0.4},
                new[] {0.1, 0.2},
                new[] {0.4, 0.05}
            });
            var awayDefencePoints = prediction.DefencePointsForAwayTeam();

            Assert.That(awayDefencePoints, Is.EqualTo(0.55m));
        }

        [Test]
        public void ShouldCalcuateAwayTeamDefencePointsForRealWorldData()
        {
            var prediction = new Prediction(new[] 
            { 
                new[] {0.008229747, 0.023701672, 0.034130407, 0.032765191, 0.023590937, 0.01358838 },
                new[] {0.015801114, 0.045507209, 0.065530381, 0.062909166, 0.0452946  , 0.026089689 },
                new[] {0.01516907,  0.043686921, 0.062909166, 0.060392799, 0.043482816, 0.025046102 },
                new[] {0.009708205, 0.027959629, 0.040261866, 0.038651392, 0.027829002, 0.016029505 },
                new[] {0.004659938, 0.013420622, 0.019325696, 0.018552668, 0.013357921, 0.007694162 },
                new[] {0.001789416, 0.005153519, 0.007421067, 0.007124225, 0.005129442, 0.002954558 }
            });
            var awayDefencePoints = prediction.DefencePointsForAwayTeam();
            Assert.That(awayDefencePoints, Is.EqualTo(0.026315626).Within(0.00001m));
        }
    }
}