using System;
using AlgorithmFinder.Application;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class DateParserTest
    {
        [Test]
        public void ShouldParseDate()
        {
            var dateParser = new DateParser();

            var date = dateParser.Parse("11-Nov-2011");

            Assert.That(date, Is.EqualTo(new DateTime(2011, 11, 11)));
        }
    }
}