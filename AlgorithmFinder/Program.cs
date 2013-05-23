using System;
using System.Collections.Generic;
using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PredictionAccuracyMeasurement;
using AlgorithmFinder.Data;

namespace AlgorithmFinder.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var resultsFilePath = args[0];
            var predictAfterDate = args[1];

            var predictionMeasurer = new PredictionMeasurer(
                new FileResultsProvider(new FileStreamer(), new ExcelLineFixtureParser(), resultsFilePath),
                new ResultPredictor());
            
            var predictionResult = predictionMeasurer.MeasureAccuracy(new DateParser().Parse(predictAfterDate));
            
            Console.WriteLine("Correct scores: {0}", predictionResult.CorrectScoreCount);

            if (args.Length == 6)
            {
                var playerName = args[2];
                var playerId = args[5];
                var teamName = args[3];
                var playerDirectoryPath = args[4];

                var pointsPredictor = new PointsPredictor(
                    new FileResultsProvider(new FileStreamer(), new ExcelLineFixtureParser(), resultsFilePath),
                    new FileTeamProvider(new FileStreamer(), new JsonPlayerDeserialiser(), playerDirectoryPath, new Dictionary<Team, List<string>>{{new Team("Wigan"), new List<string>
                        {
                            "508", "513", "514", "518", "523", "553"
                        }}})
                );
                
                var team = new Team(teamName);

                var expectedPoints = pointsPredictor.GetPointsFor(team, new DateParser().Parse(predictAfterDate), int.Parse(playerId));

                Console.WriteLine("{0}\t{1}", playerName, expectedPoints.ToString("#.##"));
            }
        } 
    }
}
