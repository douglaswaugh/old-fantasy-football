﻿using AlgorithmFinder.Application;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class PoissonDefencePointsMultiplierTests
    {
        [Test]
        public void Should_calculate_clean_sheet_multiplier()
        {
            var multiplierCalculator = new PoissonDefencePointsMultiplier(0.976502082m);

            Assert.That(multiplierCalculator.CleanSheet, Is.EqualTo(0.376626205m).Within(0.000000001m));
        }

        [Test]
        public void Should_calculate_concede_two_or_three_goals_multiplier()
        {
            var multiplierCalculator = new PoissonDefencePointsMultiplier(0.976502082m);

            Assert.That(multiplierCalculator.ConcedeTwoOrThree, Is.EqualTo(0.23801638m).Within(0.000000001m));
        }

        [Test]
        public void Should_calculate_concede_four_or_five_goals_multiplier()
        {
            var multiplierCalculator = new PoissonDefencePointsMultiplier(0.976502082m);

            Assert.That(multiplierCalculator.ConcedeFourOrFive, Is.EqualTo(0.017055681m).Within(0.000000001m));
        }
    }
}