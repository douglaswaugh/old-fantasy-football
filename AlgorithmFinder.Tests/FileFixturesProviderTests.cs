using System;
using System.IO;
using System.Linq;
using AlgorithmFinder.Data;
using AlgorithmFinder.Data.FixtureProviders;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class FileFixturesProviderTests
    {
        private CsvFileFixtureParser _parser;
        private Streamer _streamer;
        private FileFixturesProvider _fileFixturesProvider;

        private const string FourFixturesTwoBefore13NovTwoAfter = @"Home Team,Away Team,Match Date,Home Goals,Away Goals,H Shots,H Shots - Target,A Shots,A Shots - Target,Division,Season
Wigan,Wolves,13-Oct-11,3,2,14,10,10,7,1,2011
Wolves,Southampton,06-Nov-11,3,1,13,12,13,7,1,2011
Southampton,Wigan,13-Nov-11,4,2,15,5,10,3,1,2011
Wolves,Wigan,20-Nov-11,3,0,20,10,7,3,1,2011";

        [SetUp]
        public void SetUp()
        {
            _streamer = Substitute.For<Streamer>();

            _parser = new CsvFileFixtureParser(_streamer, string.Empty);

            _fileFixturesProvider = new FileFixturesProvider(_parser);
        }

        [Test]
        public void ShouldReturnTwoFixturesAfterDateFromFourFixtures()
        {
            _streamer.GetStreamReaderFor("filePath")
                     .Returns(TwoFixturesOfFourAfter2011_11_13());

            var fixtures = _fileFixturesProvider.GetFixturesAfter(new DateTime(2011, 11, 13));

            Assert.That(fixtures.Count(), Is.EqualTo(2));
        }

        private StreamReader TwoFixturesOfFourAfter2011_11_13()
        {
            return(FourFixturesTwoBefore13NovTwoAfter.ToStreamReader());
        }
    }
}