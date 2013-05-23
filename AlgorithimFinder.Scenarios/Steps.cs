using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AlgorithimFinder.Scenarios
{
    [Binding]
    public class Steps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioContext.Current["resultsContent"] = new List<string>();
            (ResultsContent()).Add(ResultsFile.ResultsFileHeadings());
        }

        [Given(@"the ""(.*)"" ""(.*)"" result on the ""(.*)"" was (\d) (\d)")]
        public void GivenTheTeamATeamBResultOnADateWasSomeHomeGoalsSomeAwayGoals(string homeTeam, string awayTeam, string date, int homeGoals, int awayGoals)
        {
            (ResultsContent()).Add(ResultsFileBuilder.SingleResult(homeTeam, awayTeam, date, homeGoals, awayGoals));
        }

        [Given(@"seven weeks fixtures have been played")]
        public void GivenSevenWeeksFixturesHaveBeenPlayed()
        {
            (ResultsContent()).AddRange(ResultsFileBuilder.ResultsForGamesweek38());
            (ResultsContent()).AddRange(ResultsFileBuilder.ResultsForGamesweek37());
            (ResultsContent()).AddRange(ResultsFileBuilder.ResultsForGamesweek36());
            (ResultsContent()).AddRange(ResultsFileBuilder.ResultsForGamesweek35());
            (ResultsContent()).AddRange(ResultsFileBuilder.ResultsForGamesweek34());
            (ResultsContent()).AddRange(ResultsFileBuilder.ResultsForGamesweek33());
            (ResultsContent()).AddRange(ResultsFileBuilder.ResultsForGamesweek32());
        }

        [Given(@"""(.*)"" has a history")]
        public void GivenAPlayerHasAHistory(string player)
        {
            ScenarioContext.Current["playersDirectoryPath"] = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            PlayerFileBuilder.WriteAlHabsiFixturesToFile(PlayersDirectoryPath());
        }

        [Given(@"the players of ""(.*)"" have a history")]
        public void GivenThePlayersOfATeamHaveAHistory(string team)
        {
            ScenarioContext.Current["playersDirectoryPath"] = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            PlayerFileBuilder.WriteBoyceFixturesToFile(PlayersDirectoryPath());

            PlayerFileBuilder.WriteFigueroaFixturesToFile(PlayersDirectoryPath());

            PlayerFileBuilder.WriteMcCarthyFixturesToFile(PlayersDirectoryPath());

            PlayerFileBuilder.WriteMaloneyFixturesToFile(PlayersDirectoryPath());

            PlayerFileBuilder.WriteKoneFixturesToFile(PlayersDirectoryPath());
        }

        [When(@"I ask for a prediction for matches after ""(.*)""")]
        public void WhenIAskForAPredictionForMatchesAfterADate(string date)
        {
            ResultsFileBuilder.CreateResultsFile();

            ApplicationRunner.RunApplicationWithParameters(new[]
                {
                    FixturesFilePath(), 
                    date
                });
        }

        [When(@"I ask for a points prediction for ""(.*)"" of ""(.*)"" for matches after ""(.*)""")]
        public void WhenIAskForAPointsPredictionForAPlayerOfATeamForMatchesAfterADate(string player, string team, string date)
        {
            ResultsFileBuilder.CreateResultsFile();

            ApplicationRunner.RunApplicationWithParameters(new[]
                {
                    FixturesFilePath(), 
                    date, 
                    player, 
                    team, 
                    PlayersDirectoryPath(), 
                    PlayerData.Ids[player].ToString()
                });
        }

        [Then(@"I should be told (.*) correct scores were predicted")]
        public void ThenIShouldBeToldANumberOfCorrectScoresWerePredicted(int correctScores)
        {
            Assert.That(ConsoleOutput(), Is.StringContaining("Correct scores: " + correctScores));
        }

        [Then(@"I should be told ""(.*)"" will get ""(.*)"" points")]
        public void ThenIShouldBeToldThePlayerWillGetANumberOfPoints(string player, decimal points)
        {
            Assert.That(ConsoleOutput(), Is.StringContaining(string.Format("{0}\t{1}", player, points)));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ContainsKey("fixturesFilePath"))
                if (File.Exists(FixturesFilePath()))
                    File.Delete(FixturesFilePath());

            if (ScenarioContext.Current.ContainsKey("playersDirectoryPath"))
                if (Directory.Exists(PlayersDirectoryPath()))
                    Directory.Delete(PlayersDirectoryPath(), true);
        }

        private static string FixturesFilePath()
        {
            return (string)ScenarioContext.Current["fixturesFilePath"];
        }

        private static List<string> ResultsContent()
        {
            return (List<string>)ScenarioContext.Current["resultsContent"];
        }

        private static string PlayersDirectoryPath()
        {
            return (string)ScenarioContext.Current["playersDirectoryPath"];
        }

        private static string ConsoleOutput()
        {
            return (string)ScenarioContext.Current["consoleOutput"];
        }
    }
}
