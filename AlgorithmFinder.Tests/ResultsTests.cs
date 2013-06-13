using System;
using System.Collections.Generic;
using AlgorithmFinder.Application;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class ResultsTests
    {
        private Team _wigan;
        private Team _wolves;
        private Fixture _wolvesWigan;
        private Score _nilNil;
        private Score _oneNil;
        private DateTime _15Dec2012;
        private Score _oneAll;
        private Score _threeTwo;
        private Score _twoAll;
        private Score _twoOne;
        private Score _threeOne;
        private Team _villa;
        private Score _oneThree;

        [SetUp]
        public void SetUp()
        {
            _wigan = new Team("Wigan");
            _wolves = new Team("Wolves");
            _villa = new Team("Aston Villa");
            _wolvesWigan = new Fixture(_wolves, _wigan, new DateTime(2011, 11, 13));
            _nilNil = new Score(0, 0);
            _oneNil = new Score(1, 0);
            _oneAll = new Score(1, 1);
            _oneThree = new Score(1, 3);
            _twoAll = new Score(2, 2);
            _twoOne = new Score(2, 1);
            _threeOne = new Score(3, 1);
            _threeTwo = new Score(3, 2);
            _15Dec2012 = new DateTime(2012, 12, 15);
        }

        [Test]
        public void Should_calculate_expected_goals_given_single_nil_nil_result()
        {
            var results = new Results(new List<Fixture> { WiganWolves(_nilNil) });
            var expectedGoals = results.ExpectedGoalsFor(_wolves, _wolvesWigan);

            Assert.That(expectedGoals.ForTeam, Is.EqualTo(0m));
            Assert.That(expectedGoals.ForOpponent, Is.EqualTo(0m));
        }

        [Test]
        public void Should_calculate_expected_goals_given_single_one_nil_result()
        {
            var results = new Results(new List<Fixture> { WiganWolves(_oneNil) });
            var expectedGoals = results.ExpectedGoalsFor(_wigan, _wolvesWigan);

            Assert.That(expectedGoals.ForTeam, Is.EqualTo(0m));
            Assert.That(expectedGoals.ForOpponent, Is.EqualTo(0m));
        }

        [Test]
        public void Should_calculate_expected_goals_given_single_one_all_result()
        {
            var results = new Results(new List<Fixture> { WiganWolves(_oneAll) });
            var expectedGoals = results.ExpectedGoalsFor(_wigan, _wolvesWigan);

            Assert.That(expectedGoals.ForTeam, Is.EqualTo(1m));
            Assert.That(expectedGoals.ForOpponent, Is.EqualTo(1m));
        }

        [Test]
        public void Should_calculate_expected_goals_given_single_three_two_result()
        {
            var results = new Results(new List<Fixture> { WiganWolves(_threeTwo) });
            var expectedGoals = results.ExpectedGoalsFor(_wigan, _wolvesWigan);

            Assert.That(expectedGoals.ForTeam, Is.EqualTo(2.88m));
            Assert.That(expectedGoals.ForOpponent, Is.EqualTo(1.92m));
        }

        [Test]
        public void Should_calculate_expected_goals_given_multiple_results()
        {
            var results = new Results(new List<Fixture>
                {
                    WolvesWigan(_twoAll),
                    WiganWolves(_twoOne)
                });

            var expectedGoals = results.ExpectedGoalsFor(_wigan, _wolvesWigan);

            Assert.That(expectedGoals.ForTeam, Is.EqualTo(1.95m).Within(0.01m));
            Assert.That(expectedGoals.ForOpponent, Is.EqualTo(1.46m).Within(0.01m));
        }

        [Test]
        public void Should_calculate_expected_goals_given_multiple_results_and_uneven_games()
        {
            var results = new Results(new List<Fixture>
                {
                    WolvesVilla(_threeOne),
                    WolvesWigan(_oneThree),
                    WiganVilla(_threeOne),
                    VillaWigan(_oneAll)
                });

            var expectedGoals = results.ExpectedGoalsFor(_wigan, _wolvesWigan);

            Assert.That(expectedGoals.ForTeam, Is.EqualTo(2.28m).Within(0.01m));
            Assert.That(expectedGoals.ForOpponent, Is.EqualTo(1.30m).Within(0.01m));
        }

        private Fixture VillaWigan(Score score)
        {
            return new Fixture(_villa, _wigan, _15Dec2012, score);
        }

        private Fixture WiganVilla(Score score)
        {
            return new Fixture(_wigan, _villa, _15Dec2012, score);
        }

        private Fixture WolvesVilla(Score score)
        {
            return new Fixture(_wolves, _villa, _15Dec2012, score);
        }

        private Fixture WolvesWigan(Score score)
        {
            return new Fixture(_wolves, _wigan, _15Dec2012, score);
        }

        private Fixture WiganWolves(Score score)
        {
            return new Fixture(_wigan, _wolves, _15Dec2012, score);
        }
    }
}