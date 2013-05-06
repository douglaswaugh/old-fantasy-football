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

        [SetUp]
        public void SetUp()
        {
            _wigan = new Team(19);
            _wolves = new Team(20);
            _wolvesWigan = new Fixture(_wolves, _wigan);
            _nilNil = new Score(0, 0);
            _oneNil = new Score(1, 0);
            _15Dec2012 = new DateTime(2012, 12, 15);
        }

        [Test]
        public void Should_give_expected_score_nil_nil_for_nil_nil_result()
        {
            var results = new Results(new List<Fixture> { WiganWolves(_nilNil) });

            var expectedGoals = results.ExpectedGoalsFor(_wolvesWigan);

            Assert.That(expectedGoals, Is.EqualTo(new ExpectedGoals(0, 0)));
        }

        [Test]
        public void Should_give_expected_score_nil_nil_for_one_nil_result()
        {
            var results = new Results(new List<Fixture> { WiganWolves(_oneNil) });

            var expectedGoals = results.ExpectedGoalsFor(_wolvesWigan);

            Assert.That(expectedGoals, Is.EqualTo(new ExpectedGoals(0, 0)));
        }

        [Test]
        public void Should_expected_one_all_score_for_one_all_result()
        {
            var results = new Results(new List<Fixture> { WiganWolves(new Score(1,1)) });

            var expectedGoals = results.ExpectedGoalsFor(_wolvesWigan);

            Assert.That(expectedGoals, Is.EqualTo(new ExpectedGoals(1, 1)));
        }

        private Fixture WiganWolves(Score score)
        {
            return new Fixture(_wigan, _wolves, _15Dec2012, score);
        }
    }
}