using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AlgorithmFinder.ConsoleUI;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AlgorithimFinder.Scenarios
{
    [Binding]
    public class Steps
    {
        private string _consoleOutput;
        private string _fixturesFilePath;
        private List<string> _resultsContent;
        private string _playersDirectoryPath;

        private string _week38 = @"Wigan,Wolves,13-May-12,3,2,14,10,10,7,1,2011
Everton,Newcastle,13-May-12,3,1,17,11,11,5,1,2011
West Brom,Arsenal,13-May-12,2,3,12,8,12,8,1,2011
Stoke,Bolton,13-May-12,2,2,12,8,20,8,1,2011
Norwich,Aston Villa,13-May-12,2,0,21,12,9,5,1,2011
Chelsea,Blackburn,13-May-12,2,1,18,6,8,5,1,2011
Swansea,Liverpool,13-May-12,1,0,13,8,14,9,1,2011
Man City,QPR,13-May-12,3,2,35,24,3,3,1,2011
Tottenham,Fulham,13-May-12,2,0,15,9,10,7,1,2011
Sunderland,Man United,13-May-12,0,1,6,5,17,9,1,2011";
        private string _week37 = @"Liverpool,Chelsea,08-May-12,4,1,23,13,9,5,1,2011
Blackburn,Wigan,07-May-12,0,1,12,7,19,9,1,2011
Wolves,Everton,06-May-12,0,0,7,1,18,10,1,2011
Aston Villa,Tottenham,06-May-12,1,1,4,2,21,10,1,2011
Bolton,West Brom,06-May-12,2,2,11,6,17,13,1,2011
Fulham,Sunderland,06-May-12,2,1,20,15,12,7,1,2011
Newcastle,Man City,06-May-12,0,2,14,9,19,12,1,2011
Man United,Swansea,06-May-12,2,0,26,18,13,9,1,2011
QPR,Stoke,06-May-12,1,0,21,12,8,1,1,2011
Arsenal,Norwich,05-May-12,3,3,20,13,12,6,1,2011";
        private string _week36 = @"Chelsea,Newcastle,02-May-12,0,2,17,6,12,6,1,2011
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
Norwich,Liverpool,28-Apr-12,0,3,8,3,15,9,1,2011";
        private string _week35 = @"Aston Villa,Bolton,24-Apr-12,1,2,17,6,12,11,1,2011
Man United,Everton,22-Apr-12,4,4,20,11,17,10,1,2011
Liverpool,West Brom,22-Apr-12,0,1,28,12,9,4,1,2011
Wolves,Man City,22-Apr-12,0,2,7,4,17,9,1,2011
Arsenal,Chelsea,21-Apr-12,0,0,13,8,13,7,1,2011
Fulham,Wigan,21-Apr-12,2,1,15,9,9,5,1,2011
Blackburn,Norwich,21-Apr-12,2,0,9,6,12,5,1,2011
Newcastle,Stoke,21-Apr-12,3,0,16,11,7,2,1,2011
Bolton,Swansea,21-Apr-12,1,1,7,5,20,12,1,2011
QPR,Tottenham,21-Apr-12,1,0,12,5,17,8,1,2011
Aston Villa,Sunderland,21-Apr-12,0,0,12,7,10,5,1,2011";
        private string _week34 = @"Arsenal,Wigan,16-Apr-12,1,2,18,8,12,7,1,2011
Man United,Aston Villa,15-Apr-12,4,0,24,16,10,4,1,2011
West Brom,QPR,14-Apr-12,1,0,15,10,16,6,1,2011
Norwich,Man City,14-Apr-12,1,6,16,8,22,17,1,2011
Swansea,Blackburn,14-Apr-12,3,0,16,8,7,2,1,2011
Sunderland,Wolves,14-Apr-12,0,0,15,6,12,8,1,2011";
        private string _week33 = @"Man City,West Brom,11-Apr-12,4,0,17,12,4,1,1,2011
Wolves,Arsenal,11-Apr-12,0,3,9,6,10,7,1,2011
Wigan,Man United,11-Apr-12,1,0,11,8,8,3,1,2011
QPR,Swansea,11-Apr-12,3,0,16,8,9,6,1,2011
Blackburn,Liverpool,10-Apr-12,2,3,10,4,16,12,1,2011
Aston Villa,Stoke,09-Apr-12,1,1,7,3,7,3,1,2011
Newcastle,Bolton,09-Apr-12,2,0,8,4,9,6,1,2011
Fulham,Chelsea,09-Apr-12,1,1,11,9,12,4,1,2011
Tottenham,Norwich,09-Apr-12,1,2,13,9,12,6,1,2011
Everton,Sunderland,09-Apr-12,4,0,22,12,3,0,1,2011";
        private string _week32 = @"Man United,QPR,08-Apr-12,2,0,24,14,9,7,1,2011
Arsenal,Man City,08-Apr-12,1,0,12,7,7,2,1,2011
Bolton,Fulham,07-Apr-12,0,3,13,7,11,8,1,2011
Chelsea,Wigan,07-Apr-12,2,1,19,10,13,7,1,2011
Liverpool,Aston Villa,07-Apr-12,1,1,21,5,5,3,1,2011
Sunderland,Tottenham,07-Apr-12,0,0,12,9,15,8,1,2011
Stoke,Wolves,07-Apr-12,2,1,14,6,9,5,1,2011
Norwich,Everton,07-Apr-12,2,2,14,11,9,5,1,2011
West Brom,Blackburn,07-Apr-12,3,0,9,6,16,10,1,2011";

        [BeforeScenario]
        public void BeforeScenario()
        {
            _resultsContent = new List<string>
            {
                "Home Team,Away Team,Match Date,Home Goals,Away Goals,H Shots,H Shots - Target,A Shots,A Shots - Target,Division,Season"
            };
        }

        [Given(@"the ""(.*)"" ""(.*)"" result on the ""(.*)"" was (\d) (\d)")]
        public void GivenTheTeamATeamBResultOnADateWasSomeHomeGoalsSomeAwayGoals(string homeTeam, string awayTeam, string date, int homeGoals, int awayGoals)
        {
            _resultsContent.Add(string.Format("{0},{1},{2},{3},{4},0,0,0,0,1,2011", homeTeam, awayTeam, date, homeGoals, awayGoals));
        }

        [Given(@"seven weeks fixtures have been played")]
        public void GivenSevenWeeksFixturesHaveBeenPlayed()
        {
            foreach (var result in _week38.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                _resultsContent.Add(result);
            }
            foreach (var result in _week37.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                _resultsContent.Add(result);
            }
            foreach (var result in _week36.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                _resultsContent.Add(result);
            }
            foreach (var result in _week35.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                _resultsContent.Add(result);
            }
            foreach (var result in _week34.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                _resultsContent.Add(result);
            }
            foreach (var result in _week33.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                _resultsContent.Add(result);
            }
            foreach (var result in _week32.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                _resultsContent.Add(result);
            }
        }

        [Given(@"""(.*)"" has the history")]
        public void GivenAPlayerHasTheHistory(string player, Table history)
        {
            var playerFixtures =
                history.Rows.Select(
                    r =>
                    string.Format(
                        @"[""{0}"", {1}, ""{2}"", {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}]",
                        string.Empty, r["Round"], r["Opponent"], r["Minutes"], r["GoalsScored"], r["Assists"],
                        r["CleanSheets"], r["GoalsConceded"], r["OwnGoals"], r["PenaltiesSaved"], r["PenaltiesMissed"],
                        r["YellowCards"], r["RedCards"], r["Saves"], r["Bonus"], 0, 0, 0, r["Points"]));


            var playersDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            AddFixturesToPlayerFile(playersDirectoryPath, player, playerFixtures);
        }

        private void AddFixturesToPlayerFile(string playersDirectoryPath, string player, IEnumerable<string> playerFixtures)
        {
            var directory = Directory.CreateDirectory(playersDirectoryPath);

            using (var writer = File.CreateText(Path.Combine(directory.FullName, PlayerData.Ids[player] + ".json")))
            {
                var jsonResults = string.Empty;

                foreach (var playerFixture in  playerFixtures)
                {
                    if (jsonResults != string.Empty)
                        jsonResults += ", ";

                    var jsonResult = playerFixture;

                    jsonResults += jsonResult;
                }

                _playersDirectoryPath = playersDirectoryPath;

                writer.WriteLine(PlayerData.Formats[player], jsonResults);
            }
        }

        [Given(@"the players of ""(.*)"" have a history")]
        public void GivenThePlayersOfHaveAHistory(string p0)
        {
            var playersDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            var boyceFixtures = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 50, 1]",
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 19, -176, 50, 6]",
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 11, 3157, 50, 1]",
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 1, 0, 0, 0, 4, -172, 50, -1]",
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 76, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, -384, 50, 1]",
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Boyce", boyceFixtures);

            var figueroaFixtures = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 9, 0, 45, 1]", 
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 2, 24, -4183, 45, 9]", 
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 34421, 45, 1]", 
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 7, 1773, 45, 0]", 
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 1, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 10, -3732, 45, 1]", 
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Figueroa", figueroaFixtures);

            var mcCarthyFixtures = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 5, 0, 50, 2]", 
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 19, -2277, 50, 3]", 
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 5, -2648, 50, 5]", 
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 6, -1643, 50, 2]", 
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 10, -1000, 49, 2]", 
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "McCarthy", mcCarthyFixtures);

            var maloney = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 47, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 7, 0, 50, 1]",
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 74, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 21, -1162, 50, 7]",
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 20, 4283, 50, 7]",
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 58, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 6, 10630, 50, 1]",
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 1830, 50, 2]",
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Maloney", maloney);

            var koneFixtures = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 65, 1]",
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 20, -228, 65, 6]",
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 14, 3784, 65, 5]",
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, -207, 65, 2]",
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 27, -626, 65, 6]",
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Kone", koneFixtures);
        }

        [When(@"I ask for a prediction for matches after ""(.*)""")]
        public void WhenIAskForAPredictionForMatchesAfterADate(string date)
        {
            CreateResultsFile();

            RunApplicationWithParameters(new[] { _fixturesFilePath, date });
        }

        [When(@"I ask for a points prediction for ""(.*)"" of ""(.*)"" for matches after ""(.*)""")]
        public void WhenIAskForAPointsPredictionForAPlayerOfATeamForMatchesAfterADate(string player, string team, string date)
        {
            CreateResultsFile();

            RunApplicationWithParameters(new[] { _fixturesFilePath, date, player, team, _playersDirectoryPath, PlayerData.Ids[player].ToString() });
        }

        [Then(@"I should be told (.*) correct scores were predicted")]
        public void ThenIShouldBeToldANumberOfCorrectScoresWerePredicted(int correctScores)
        {
            Assert.That(_consoleOutput, Is.StringContaining("Correct scores: " + correctScores));
        }

        [Then(@"I should be told ""(.*)"" will get ""(.*)"" points")]
        public void ThenIShouldBeToldThePlayerWillGetANumberOfPoints(string player, decimal points)
        {
            Assert.That(_consoleOutput, Is.StringContaining(string.Format("{0}\t{1}", player, points)));
        }


        [AfterScenario]
        public void AfterScenario()
        {
            if (File.Exists(_fixturesFilePath))
                File.Delete(_fixturesFilePath);

            if (Directory.Exists(_playersDirectoryPath))
                Directory.Delete(_playersDirectoryPath, true);
        }

        private void CreateResultsFile()
        {
            _fixturesFilePath = Path.GetTempFileName();
            var resultsFile = new FileInfo(_fixturesFilePath);
            using (var writer = resultsFile.CreateText())
            {
                foreach (var resultContent in _resultsContent)
                {
                    writer.WriteLine(resultContent);
                }
            }
        }

        private void RunApplicationWithParameters(string[] args)
        {
            var originalStandardOutputStream = Console.OpenStandardOutput();

            var standardOutput = new StreamWriter(originalStandardOutputStream) { AutoFlush = true };

            var writer = new StringWriter();

            Console.SetOut(writer);

            Program.Main(args);

            _consoleOutput = writer.ToString();

            Console.SetOut(standardOutput);

            writer.Dispose();
        }
    }
}
