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
            var predictionMeasurer = new PredictionMeasurer(
                new FileResultsProvider(new FileStreamer(), new ExcelLineFixtureParser(), args[0]),
                new ResultPredictor(new PoissonMatrix()));
            
            var predictionResult = predictionMeasurer.MeasureAccuracy(new DateParser().Parse(args[1]));
            
            Console.WriteLine("Correct scores: {0}", predictionResult.CorrectScoreCount);

            if (args.Length == 6)
            {
                var pointsPredictor = new PointsPredictor(
                    new FileResultsProvider(new FileStreamer(), new ExcelLineFixtureParser(), args[0]),
                    new FileTeamProvider(new FileStreamer(), new JsonPlayerDeserialiser(), args[4], new Dictionary<int, List<string>>{{20, new List<string>{"508", "513"}}}),
                    new PoissonMatrix()
                );

                var team = new Team(args[3], 20);

                var expectedPoints = pointsPredictor.GetPointsFor(20, new DateParser().Parse(args[1]), int.Parse(args[5]));

                Console.WriteLine("{0}\t{1}", args[2], expectedPoints.ToString("#.##"));
            }
        } 
    }
}
