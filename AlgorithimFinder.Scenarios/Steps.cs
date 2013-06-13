using System;
using System.Collections.Generic;
using System.IO;
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

        [Given(@"the ""(.*)"" ""(.*)"" fixture is on the ""(.*)""")]
        public void GivenTheHomeTeamAwayTeamFixtureIsOnTheDate(string homeTeam, string awayTeam, string date)
        {
            FixtureFileBuilder.WriteFixtureToFile(homeTeam, awayTeam, date);
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

        [Given(@"a player has played (.*) minutes in each  of thier last (.*) games")]
        public void GivenAPlayerHasPlayedSomeMinutesInEachOfThierLastNumberOfGames(int minutes, int numberOfGames)
        {
            ScenarioContext.Current["playersDirectoryPath"] = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            PlayerFileBuilder.WriteFixturesToFileWithMintues(PlayersDirectoryPath(), 90);
        }
        
        [When(@"I ask for the points prediction for the player")]
        public void WhenIAskForThePointsPredictionForThePlayer()
        {
            (ResultsContent()).Add(ResultsFileBuilder.SingleResult("Wigan", "Wolves", "11-Oct-2011", 3, 2));

            ResultsFileBuilder.CreateResultsFile();

            FixtureFileBuilder.WriteFixtureToFile("Wolves", "Wigan", "15-Nov-2011");

            ApplicationRunner.RunApplicationWithParameters(new[]
                {
                    ResultsFilePath(),
                    "13-Nov-2011",
                    "Al Habsi", 
                    "Wigan", 
                    PlayersDirectoryPath(), 
                    PlayerData.Ids["Al Habsi"].ToString(),
                    FixturesFilePath()
                });
        }

        [When(@"I ask for a prediction for matches after ""(.*)""")]
        public void WhenIAskForAPredictionForMatchesAfterADate(string date)
        {
            ResultsFileBuilder.CreateResultsFile();

            ApplicationRunner.RunApplicationWithParameters(new[]
                {
                    ResultsFilePath(), 
                    date
                });
        }

        [When(@"I ask for a points prediction for ""(.*)"" of ""(.*)"" for matches after ""(.*)""")]
        public void WhenIAskForAPointsPredictionForAPlayerOfATeamForMatchesAfterADate(string player, string team, string date)
        {
            ResultsFileBuilder.CreateResultsFile();

            ApplicationRunner.RunApplicationWithParameters(new[]
                {
                    ResultsFilePath(), 
                    date, 
                    player, 
                    team, 
                    PlayersDirectoryPath(), 
                    PlayerData.Ids[player].ToString(),
                    FixturesFilePath()
                });
        }

        [Then(@"I should be told (.*) correct scores were predicted")]
        public void ThenIShouldBeToldANumberOfCorrectScoresWerePredicted(int correctScores)
        {
            Assert.That(Convert.ToInt32(ConsoleOutput()), Is.EqualTo(correctScores));
        }

        [Then(@"I should be told ""(.*)"" will get ""(.*)"" points")]
        public void ThenIShouldBeToldThePlayerWillGetANumberOfPoints(string player, decimal points)
        {
            Assert.That(Convert.ToDecimal(ConsoleOutput()), Is.EqualTo(points).Within(0.01m));
        }

        [Then(@"the player should not be given any points for playing")]
        public void ThenThePlayerShouldNotBeGivenAnyPointsForPlaying()
        {
            // then assert that the player has a certain number of points
            // I suppose for zero minutes played there's going to be no difference
            // but when I get to the other scenarios it will be more interesting
            // at that point I can get two points predictions and compare them

            // what can I do for it shouldn't add any points?  I can't think of a 
            // test I can do, so perhaps I should just go straight for a more interesting 
            // test.  isn't it implied that no points will be added for 0 minutes played,
            // if all other scenarios add points?
            ScenarioContext.Current.Pending();
        }

        [Then(@"the player should be predicted (.*) extra points")]
        public void ThenThePlayerShouldBePredictedExtraNumberOfPoints(int points)
        {
            var extraPoints = Convert.ToDecimal(ConsoleOutput());

            ScenarioContext.Current["playersDirectoryPath"] = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            PlayerFileBuilder.WriteFixturesToFileWithMintues(PlayersDirectoryPath(), 0);

            ApplicationRunner.RunApplicationWithParameters(new[]
                {
                    ResultsFilePath(),
                    "13-Nov-2011",
                    "Al Habsi", 
                    "Wigan", 
                    PlayersDirectoryPath(), 
                    PlayerData.Ids["Al Habsi"].ToString(),
                    FixturesFilePath()
                });

            var normalPoints = Convert.ToDecimal(ConsoleOutput());

            Assert.That(extraPoints - normalPoints, Is.EqualTo(2m));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ContainsKey("resultsFilePath"))
                if (File.Exists(ResultsFilePath()))
                    File.Delete(ResultsFilePath());

            if (ScenarioContext.Current.ContainsKey("playersDirectoryPath"))
                if (Directory.Exists(PlayersDirectoryPath()))
                    Directory.Delete(PlayersDirectoryPath(), true);
        }

        private string FixturesFilePath()
        {
            if (ScenarioContext.Current.ContainsKey("fixturesFilePath"))
                return (string)ScenarioContext.Current["fixturesFilePath"];

            return ResultsFilePath();
        }

        private static string ResultsFilePath()
        {
            return (string)ScenarioContext.Current["resultsFilePath"];
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