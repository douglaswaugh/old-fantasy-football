﻿using System;
using System.Collections.Generic;
using AlgorithmFinder.Application;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class ResultsProviderTests
    {
        [Test]
        public void ShouldCalculateExpectedHomeGoalsCorrectly()
        {
            var results = new Results(new List<Fixture>
                {
                    new Fixture(
                        new Team("Wigan", 2), 
                        new Team("Wolves", 1), 
                        new DateTime(2012, 9, 16),
                        new Score(3, 2))
                });

            var fixture = new Fixture(new Team("Wolves", 1), new Team("Wigan", 2));

            Assert.That(results.ExpectedHomeGoals(fixture), Is.EqualTo(1.92d));
        }

        [Test]
        public void ShouldCalculateExpectedAwayGoalsCorrectly()
        {
            var results = new Results(new List<Fixture>
                {
                    new Fixture(
                        new Team("Wigan", 2), 
                        new Team("Wolves", 1), 
                        new DateTime(2012, 9, 16),
                        new Score(3, 2))
                });

            var fixture = new Fixture(new Team("Wolves", 1), new Team("Wigan", 2));

            Assert.That(results.ExpectedAwayGoals(fixture), Is.EqualTo(2.88d));
        }
    }
}