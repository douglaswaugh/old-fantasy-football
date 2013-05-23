using System;
using System.IO;
using AlgorithmFinder.ConsoleUI;
using TechTalk.SpecFlow;

namespace AlgorithimFinder.Scenarios
{
    public class ApplicationRunner
    {
        public static void RunApplicationWithParameters(string[] args)
        {
            var originalStandardOutputStream = Console.OpenStandardOutput();

            var standardOutput = new StreamWriter(originalStandardOutputStream) { AutoFlush = true };

            var writer = new StringWriter();

            Console.SetOut(writer);

            Program.Main(args);

            ScenarioContext.Current["consoleOutput"] = writer.ToString();

            Console.SetOut(standardOutput);

            writer.Dispose();
        }
    }
}