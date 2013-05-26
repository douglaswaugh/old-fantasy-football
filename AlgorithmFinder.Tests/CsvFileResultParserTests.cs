using System;
using AlgorithmFinder.Application;
using AlgorithmFinder.Data;
using AlgorithmFinder.Data.FixtureProviders;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class CsvFileResultParserTests
    {
        [Test]
        public void ShouldParseExcelLine()
        {
            // Home Team,Away Team,Match Date,
            // Home Goals,Away Goals,
            // H Shots,H Shots - Target,A Shots,A Shots - Target,
            // Division,Season
            var resultLine = @"Home Team, AwayTeam, Match Date, Home Goals, Away Goals, H Shots,H Shots - Target,A Shots,A Shots - Target,Division,Season
Reading,Tottenham,16-Sep-12,1,3,7,2,23,8,1,2012".ToStreamReader();

            var streamer = Substitute.For<Streamer>();
            streamer.GetStreamReaderFor(string.Empty).Returns(resultLine);

            var result = new CsvFileFixtureParser(streamer, string.Empty).ParseFixtures(resultLine);

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
