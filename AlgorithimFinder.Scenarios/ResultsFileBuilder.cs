using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace AlgorithimFinder.Scenarios
{
    public class ResultsFileBuilder
    {
        public static string SingleResult(string homeTeam, string awayTeam, string date, int homeGoals, int awayGoals)
        {
            return String.Format("{0},{1},{2},{3},{4},0,0,0,0,1,2011", homeTeam, awayTeam, date, homeGoals, awayGoals);
        }

        public static IEnumerable<string> ResultsForGamesweek32()
        {
            return @"Man United,QPR,08-Apr-12,2,0,24,14,9,7,1,2011
Arsenal,Man City,08-Apr-12,1,0,12,7,7,2,1,2011
Bolton,Fulham,07-Apr-12,0,3,13,7,11,8,1,2011
Chelsea,Wigan,07-Apr-12,2,1,19,10,13,7,1,2011
Liverpool,Aston Villa,07-Apr-12,1,1,21,5,5,3,1,2011
Sunderland,Tottenham,07-Apr-12,0,0,12,9,15,8,1,2011
Stoke,Wolves,07-Apr-12,2,1,14,6,9,5,1,2011
Norwich,Everton,07-Apr-12,2,2,14,11,9,5,1,2011
West Brom,Blackburn,07-Apr-12,3,0,9,6,16,10,1,2011".Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static IEnumerable<string> ResultsForGamesweek33()
        {
            return @"Man City,West Brom,11-Apr-12,4,0,17,12,4,1,1,2011
Wolves,Arsenal,11-Apr-12,0,3,9,6,10,7,1,2011
Wigan,Man United,11-Apr-12,1,0,11,8,8,3,1,2011
QPR,Swansea,11-Apr-12,3,0,16,8,9,6,1,2011
Blackburn,Liverpool,10-Apr-12,2,3,10,4,16,12,1,2011
Aston Villa,Stoke,09-Apr-12,1,1,7,3,7,3,1,2011
Newcastle,Bolton,09-Apr-12,2,0,8,4,9,6,1,2011
Fulham,Chelsea,09-Apr-12,1,1,11,9,12,4,1,2011
Tottenham,Norwich,09-Apr-12,1,2,13,9,12,6,1,2011
Everton,Sunderland,09-Apr-12,4,0,22,12,3,0,1,2011".Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static IEnumerable<string> ResultsForGamesweek34()
        {
            return @"Arsenal,Wigan,16-Apr-12,1,2,18,8,12,7,1,2011
Man United,Aston Villa,15-Apr-12,4,0,24,16,10,4,1,2011
West Brom,QPR,14-Apr-12,1,0,15,10,16,6,1,2011
Norwich,Man City,14-Apr-12,1,6,16,8,22,17,1,2011
Swansea,Blackburn,14-Apr-12,3,0,16,8,7,2,1,2011
Sunderland,Wolves,14-Apr-12,0,0,15,6,12,8,1,2011".Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static IEnumerable<string> ResultsForGamesweek35()
        {
            return @"Aston Villa,Bolton,24-Apr-12,1,2,17,6,12,11,1,2011
Man United,Everton,22-Apr-12,4,4,20,11,17,10,1,2011
Liverpool,West Brom,22-Apr-12,0,1,28,12,9,4,1,2011
Wolves,Man City,22-Apr-12,0,2,7,4,17,9,1,2011
Arsenal,Chelsea,21-Apr-12,0,0,13,8,13,7,1,2011
Fulham,Wigan,21-Apr-12,2,1,15,9,9,5,1,2011
Blackburn,Norwich,21-Apr-12,2,0,9,6,12,5,1,2011
Newcastle,Stoke,21-Apr-12,3,0,16,11,7,2,1,2011
Bolton,Swansea,21-Apr-12,1,1,7,5,20,12,1,2011
QPR,Tottenham,21-Apr-12,1,0,12,5,17,8,1,2011
Aston Villa,Sunderland,21-Apr-12,0,0,12,7,10,5,1,2011".Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static IEnumerable<string> ResultsForGamesweek36()
        {
            return @"Chelsea,Newcastle,02-May-12,0,2,17,6,12,6,1,2011
Bolton,Tottenham,02-May-12,1,4,14,8,13,10,1,2011
Liverpool,Fulham,01-May-12,0,1,18,5,7,4,1,2011
Stoke,Everton,01-May-12,1,1,10,5,11,4,1,2011
Man City,Man United,30-Apr-12,1,0,12,5,4,2,1,2011
Tottenham,Blackburn,29-Apr-12,2,0,19,8,0,0,1,2011
Chelsea,QPR,29-Apr-12,6,1,25,18,11,7,1,2011
West Brom,Aston Villa,28-Apr-12,0,0,13,7,8,5,1,2011
Sunderland,Bolton,28-Apr-12,2,2,12,6,16,9,1,2011
Swansea,Wolves,28-Apr-12,4,4,10,8,15,9,1,2011
Wigan,Newcastle,28-Apr-12,4,0,10,8,11,3,1,2011
Stoke,Arsenal,28-Apr-12,1,1,6,4,17,10,1,2011
Everton,Fulham,28-Apr-12,4,0,11,7,6,5,1,2011
Norwich,Liverpool,28-Apr-12,0,3,8,3,15,9,1,2011".Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static IEnumerable<string> ResultsForGamesweek37()
        {
            return @"Liverpool,Chelsea,08-May-12,4,1,23,13,9,5,1,2011
Blackburn,Wigan,07-May-12,0,1,12,7,19,9,1,2011
Wolves,Everton,06-May-12,0,0,7,1,18,10,1,2011
Aston Villa,Tottenham,06-May-12,1,1,4,2,21,10,1,2011
Bolton,West Brom,06-May-12,2,2,11,6,17,13,1,2011
Fulham,Sunderland,06-May-12,2,1,20,15,12,7,1,2011
Newcastle,Man City,06-May-12,0,2,14,9,19,12,1,2011
Man United,Swansea,06-May-12,2,0,26,18,13,9,1,2011
QPR,Stoke,06-May-12,1,0,21,12,8,1,1,2011
Arsenal,Norwich,05-May-12,3,3,20,13,12,6,1,2011".Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static IEnumerable<string> ResultsForGamesweek38()
        {
            return @"Wigan,Wolves,13-May-12,3,2,14,10,10,7,1,2011
Everton,Newcastle,13-May-12,3,1,17,11,11,5,1,2011
West Brom,Arsenal,13-May-12,2,3,12,8,12,8,1,2011
Stoke,Bolton,13-May-12,2,2,12,8,20,8,1,2011
Norwich,Aston Villa,13-May-12,2,0,21,12,9,5,1,2011
Chelsea,Blackburn,13-May-12,2,1,18,6,8,5,1,2011
Swansea,Liverpool,13-May-12,1,0,13,8,14,9,1,2011
Man City,QPR,13-May-12,3,2,35,24,3,3,1,2011
Tottenham,Fulham,13-May-12,2,0,15,9,10,7,1,2011
Sunderland,Man United,13-May-12,0,1,6,5,17,9,1,2011".Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static void CreateResultsFile()
        {
            ScenarioContext.Current["fixturesFilePath"] = Path.GetTempFileName();
            var resultsFile = new FileInfo(ScenarioContext.Current.Get<string>("fixturesFilePath"));
            using (var writer = resultsFile.CreateText())
            {
                foreach (var resultContent in ((List<string>)ScenarioContext.Current["resultsContent"]))
                {
                    writer.WriteLine(resultContent);
                }
            }
        }
    }
}