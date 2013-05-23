using System;
using AlgorithmFinder.Application;
using AlgorithmFinder.Data;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class ExcelLineResultParserTests
    {
        [Test]
        public void ShouldParseExcelLine()
        {
            // Home Team,Away Team,Match Date,
            // Home Goals,Away Goals,
            // H Shots,H Shots - Target,A Shots,A Shots - Target,
            // Division,Season
            const string resultLine = "Reading,Tottenham,16-Sep-12,1,3,7,2,23,8,1,2012";

            var result = new ExcelLineFixtureParser().ParseFixtre(resultLine);

            Assert.That(result, Is.EqualTo(NewResult()));
        }

        private static Fixture NewResult()
        {
            return new Fixture(
                new Team("Reading"), 
                new Team("Tottenham"), 
                new DateTime(2012, 9, 16),
                new Score(1, 3));
        }
    }
}
