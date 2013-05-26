using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmFinder.Application;
using AlgorithmFinder.Data;
using AlgorithmFinder.Data.FixtureProviders;
using NSubstitute;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class JsonFileFixtureParserTests
    {
        [Test]
        public void Should_split_fixture_file_in_to_fixtures()
        {
            Assert.That(GetFixtures(TwoFixtures()).Count(), Is.EqualTo(2));
        }

        [Test]
        public void Deserialized_fixtures_should_have_home_team()
        {
            Assert.That(GetFixtures(OneFixture()).First().HomeTeam, Is.EqualTo(new Team("Arsenal")));
        }

        [Test]
        public void Deserialized_fixtures_should_have_away_team()
        {
            Assert.That(GetFixtures(OneFixture()).First().AwayTeam, Is.EqualTo(new Team("West Brom")));
        }

        [Test]
        public void Deserialized_fixtures_should_have_a_score()
        {
            Assert.That(GetFixtures(OneFixture()).First().HomeGoals(), Is.EqualTo(3));
            Assert.That(GetFixtures(OneFixture()).First().AwayGoals(), Is.EqualTo(0));
        }

        [Test]
        public void Deserialized_fixtures_should_have_a_date()
        {
            Assert.That(GetFixtures(OneFixture()).First().IsBefore(new DateTime(2011, 11, 5, 15, 0, 0, 1)), Is.True);
        }

        [Test]
        public void Deserialized_fixture_should_be_on_or_after_date()
        {
            Assert.That(GetFixtures(OneFixture()).First().IsOnOrAfter(new DateTime(2011, 11, 5, 15, 0, 0)), Is.True);
        }

        private static IEnumerable<Fixture> GetFixtures(string fixturesString)
        {
            var reader = fixturesString.ToStreamReader();

            var filePath = @"c:\filepath";

            var streamer = Substitute.For<Streamer>();
            streamer.GetStreamReaderFor(filePath).Returns(reader);

            var fixtureParser = new JsonFileFixtureParser(streamer, filePath);

            var fixtures = fixtureParser.GetFixtures();

            return fixtures;
        }

        private static string OneFixture()
        {
            return @"{
   ""completed"":true,
   ""fixtures"":[
    {
         ""awayGoals"":0,
         ""awayTeam"":{
            ""name"":""West Brom""
         },
         ""date"":""\/Date(1320505200000+0000)\/"",
         ""homeGoals"":3,
         ""homeTeam"":{
            ""name"":""Arsenal""
         },
         ""played"":true
      }
   ],
   ""started"":true
}";
        }

        private static string TwoFixtures()
        {
            return @"{
   ""completed"":true,
   ""fixtures"":[
      {
         ""awayGoals"":1,
         ""awayTeam"":{
            ""name"":""Everton""
         },
         ""date"":""\/Date(1320497100000+0000)\/"",
         ""homeGoals"":2,
         ""homeTeam"":{
            ""name"":""Newcastle""
         },
         ""played"":true
      },
      {
         ""awayGoals"":0,
         ""awayTeam"":{
            ""name"":""West Brom""
         },
         ""date"":""\/Date(1320505200000+0000)\/"",
         ""homeGoals"":3,
         ""homeTeam"":{
            ""name"":""Arsenal""
         },
         ""played"":true
      }
   ],
   ""started"":true
}";
        }
    }
}