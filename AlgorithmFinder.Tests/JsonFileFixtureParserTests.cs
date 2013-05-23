using System.Linq;
using AlgorithmFinder.Data;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class JsonFileFixtureParserTests
    {
        [Test]
        public void Should_split_fixture_file_in_to_fixtures()
        {
            var reader = @"{
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
}".ToStreamReader();
            
            var fixtureParser = new JsonFileFixtureParser();
            var fixtures = fixtureParser.ParseFixtures(reader);
            Assert.That(fixtures.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Deserialized_fixtures_should_have_home_team()
        {
            var reader = @"{
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
}".ToStreamReader();

            var fixtureParser = new JsonFileFixtureParser();
            var fixtures = fixtureParser.ParseFixtures(reader);
            Assert.That(fixtures.First().HomeTeam.Name, Is.EqualTo("Arsenal"));
        }
    }
}