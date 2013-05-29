using System;
using System.Collections.Generic;
using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class ExpectedPointsCalculatorTests
    {
        private Team _wigan;
        private Team _wolves;

        [SetUp]
        public void SetUp()
        {
            _wigan = new Team("Wigan");

            var fixtures = new List<PlayerFixture>
                {
                    NewPlayerFixture(0, 0, 1, 0, 0), 
                    NewPlayerFixture(0, 0, 2, 1, 0)
                };

            _wigan.AddPlayer(new Player(514, "Kone", new ForwardPointsCalculator(), new FixtureHistory(fixtures), _wigan));

            _wolves = new Team("Wolves");
        }

        [Test]
        public void Should_calculate_expected_points()
        {
            var expectedGoalsCalculator = Substitute.For<ExpectedGoalsCalculator>();

            expectedGoalsCalculator
                .ExpectedGoalsFor(_wigan, NewFixture())
                .Returns(new ExpectedGoals(2.88m, 1.92m));

            var expectedPointsCalculator = new ExpectedPointsCalculator(expectedGoalsCalculator);

            var fixtures = new List<PlayerFixture>();

            fixtures.Add(NewPlayerFixture(0, 0, 0, 1, 0, 2));
            fixtures.Add(NewPlayerFixture(0, 0, 1, 0, 0));
            fixtures.Add(NewPlayerFixture(0, 0, 2, 2, 1));
            fixtures.Add(NewPlayerFixture(0, 0, 1, 0, 1));
            fixtures.Add(NewPlayerFixture(0, 1, 0, 1, 0));

            var figueroa = new Player(508, "Figueroa", new DefenderPointsCalculator(), new FixtureHistory(fixtures), _wigan);

            _wigan.AddPlayer(figueroa);

            var expectedPoints = expectedPointsCalculator.GetPointsFor(
                figueroa, 
                NewFixture());

            Assert.That(expectedPoints, Is.EqualTo(15.2997m).Within(0.0001m));
        }

        private Fixture NewFixture()
        {
            return new Fixture(_wolves, _wigan, new DateTime(2011, 11, 13));
        }

        private PlayerFixture NewPlayerFixture(int saves, int bonus, int goals, int assists, int yellowCards, int redCards = 0)
        {
            return new PlayerFixture(saves, bonus, goals, assists, yellowCards, redCards);
        }
    }
}