using System;
using System.IO;
using TechTalk.SpecFlow;

namespace AlgorithimFinder.Scenarios
{
    public class FixtureFileBuilder
    {
        public static void WriteFixtureToFile(string homeTeam, string awayTeam, string date)
        {
            var results = @"{{
   ""completed"":true,
   ""fixtures"":[
      {{
         ""awayGoals"":1,
         ""awayTeam"":{{
            ""name"":""{1}""
         }},
         ""date"":""\/Date({2}+0000)\/"",
         ""homeGoals"":3,
         ""homeTeam"":{{
            ""name"":""{0}""
         }},
         ""played"":true
      }}
   ],
   ""started"":true
}}";
            var fixturesFileName = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            var javascriptDate = DateTime.Parse(date).Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;

            File.WriteAllText(fixturesFileName, string.Format(results, homeTeam, awayTeam, javascriptDate));

            ScenarioContext.Current["fixturesFilePath"] = fixturesFileName;
        }
    }
}