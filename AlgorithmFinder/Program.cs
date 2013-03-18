using AlgorithmFinder.Application;
using AlgorithmFinder.Data;

namespace AlgorithmFinder.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var resultPredictor = 
                new ResultPredictor(
                    new FileResultsProvider(
                        new FileStreamer(args[0]), new ExcelLineResultParser()));

            var predictionResult = resultPredictor.GetPredictionResult();

            System.Console.WriteLine("{0}", predictionResult.CorrectScoreCount);
        } 
    }
}
