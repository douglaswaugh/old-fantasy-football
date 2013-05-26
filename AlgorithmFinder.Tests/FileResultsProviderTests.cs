using System;
using System.IO;
using System.Linq;
using AlgorithmFinder.Data;
using AlgorithmFinder.Data.FixtureProviders;
using AlgorithmFinder.Data.FixtureProviders.Csv;
using AlgorithmFinder.Data.ResultProviders;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class FileResultsProviderTests
    {
        private CsvFileFixtureParser _parser;
        private Streamer _streamer;
        private FileResultsProvider _fileResultsProvider;

        private const string TwoFixturesOneBefore13NovOneAfter = @"Home Team,Away Team,Match Date,Home Goals,Away Goals,H Shots,H Shots - Target,A Shots,A Shots - Target,Division,Season
Wigan,Wolves,06-Nov-11,3,2,14,10,10,7,1,2011
Wolves,Wigan,13-Nov-11,3,1,13,12,13,7,1,2011";

        private const string FourFixturesTwoBefore13NovTwoAfter = @"Home Team,Away Team,Match Date,Home Goals,Away Goals,H Shots,H Shots - Target,A Shots,A Shots - Target,Division,Season
Wigan,Wolves,13-Oct-11,3,2,14,10,10,7,1,2011
Wolves,Southampton,06-Nov-11,3,1,13,12,13,7,1,2011
Southampton,Wigan,13-Nov-11,4,2,15,5,10,3,1,2011
Wolves,Wigan,20-Nov-11,3,0,20,10,7,3,1,2011";

        [SetUp]
        public void SetUp()
        {
            _streamer = Substitute.For<Streamer>();

            _parser =  new CsvFileFixtureParser(_streamer, string.Empty);

            _fileResultsProvider = new FileResultsProvider(_parser);
        }

        [Test]
        public void ShouldReturnNoResultsBeforeDateFromTwoFixtures()
        {
            _streamer.GetStreamReaderFor(string.Empty).Returns(TwoFixturesOfTwoAfter2011_11_06());

            var results = _fileResultsProvider.GetResultsBefore(new DateTime(2011, 11, 6));

            Assert.That(results.Count(), Is.EqualTo(0));
        }

        [Test]
        public void ShouldReturnTwoFixturesAfterDateFromFourFixtures()
        {
            _streamer.GetStreamReaderFor(string.Empty).Returns(TwoFixturesOfFourAfter2011_11_13());

            var fixtures = _fileResultsProvider.GetFixturesAfter(new DateTime(2011, 11, 13));

            Assert.That(fixtures.Count(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldReturnTwoResultsBeforeDateFromTwoFixtures()
        {
            _streamer.GetStreamReaderFor(string.Empty).Returns(TwoFixturesOfTwoAfter2011_11_06());

            var results = _fileResultsProvider.GetResultsBefore(new DateTime(2011, 11, 14));

            Assert.That(results.Count(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldReturnTwoResultsBeforeDateFromFourFixtures()
        {
            _streamer.GetStreamReaderFor(string.Empty).Returns(TwoFixturesOfFourAfter2011_11_13());

            var results = _fileResultsProvider.GetResultsBefore(new DateTime(2011, 11, 13));

            Assert.That(results.Count(), Is.EqualTo(2));
        }

        private StreamReader TwoFixturesOfTwoAfter2011_11_06()
        {
            return LoadStringInToStream(TwoFixturesOneBefore13NovOneAfter);
        }

        private StreamReader TwoFixturesOfFourAfter2011_11_13()
        {
            return LoadStringInToStream(FourFixturesTwoBefore13NovTwoAfter);
        }

        private static StreamReader LoadStringInToStream(string @string)
        {
            var stream = new MemoryStream();

            var writer = new StreamWriter(stream);

            writer.Write(@string);

            writer.Flush();

            stream.Position = 0;

            return new StreamReader(stream);
        }
    }
}