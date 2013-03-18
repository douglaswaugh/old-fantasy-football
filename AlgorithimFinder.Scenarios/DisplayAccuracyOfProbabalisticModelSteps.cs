using System;
using System.IO;
using AlgorithmFinder.ConsoleUI;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AlgorithimFinder.Scenarios
{
    [Binding]
    public class DisplayAccuracyOfProbabalisticModelSteps
    {
        private string _output;
        private string _path;
        private string _numberOfResults;

        [Given(@"two matches have been played")]
        public void GivenTwoMatchesHaveBeenPlayed()
        {
            _path = Path.GetTempFileName();
            var resultsFile = new FileInfo(_path);
            using (var writer = resultsFile.CreateText())
            {
                writer.WriteLine(
                    "Home Team,Away Team,Match Date,Home Goals,Away Goals,H Shots,H Shots - Target,A Shots,A Shots - Target,Division,Season");
                writer.WriteLine("Wigan,Wolves,13-May-12,3,2,14,10,10,7,1,2011");
                writer.WriteLine("Wolves,Wigan,06-Nov-11,3,1,13,12,13,7,1,2011");
            }
        }

        [Given(@"the probabalistic model uses the last fixture")]
        public void GivenTheProbabalisticModelUsesTheLastFixture()
        {
            _numberOfResults = "1";
        }

        [When(@"I calculate the result of the second match")]
        public void WhenICalculateTheResultOfTheSecondMatch()
        {
            var writer = new StringWriter();
            
            Console.SetOut(writer);

            Program.Main(new[] { _path, _numberOfResults });

            _output = writer.ToString();

            var standardOutput = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };

            Console.SetOut(standardOutput);
            
            writer.Dispose();
        }

        [Then(@"I should be told how many correct scores were predicted")]
        public void ThenIShouldBeToldHowManyCorrectScoresWerePredicted()
        {
            Assert.That(_output, Is.EqualTo("Correct scores: 0"));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var fileInfo = new FileInfo(_path);
            fileInfo.Delete();
        }
    }
}
