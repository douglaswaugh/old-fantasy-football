// <copyright file="PoissonDistribution.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://numerics.mathdotnet.com
// http://github.com/mathnet/mathnet-numerics
// http://mathnetnumerics.codeplex.com
// Copyright (c) 2009-2010 Math.NET
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

using System;
using MathNet.Numerics.Distributions;

namespace DW.FantasyFootball.Console.Samples.MathNet.Numerics.DiscreteDistributionsExamples
{
    /// <summary>
    /// Poisson distribution example
    /// </summary>
    public class PoissonDistribution : IExample
    {
        /// <summary>
        /// Gets the name of this example
        /// </summary>
        /// <seealso cref="http://reference.wolfram.com/mathematica/ref/PoissonDistribution.html"/>
        public string Name
        {
            get
            {
                return "Poisson distribution";
            }
        }

        /// <summary>
        /// Gets the description of this example
        /// </summary>
        public string Description
        {
            get
            {
                return "Poisson distribution properties and samples generating examples";
            }
        }

        /// <summary>
        /// Run example
        /// </summary>
        /// <a href="http://en.wikipedia.org/wiki/Poisson_distribution">Poisson distribution</a>
        public void Run()
        {
            // 1. Initialize the new instance of the Poisson distribution class with parameter Lambda = 1
            var poisson = new Poisson(1);
            System.Console.WriteLine(@"1. Initialize the new instance of the Poisson distribution class with parameter Lambda = {0}", poisson.Lambda);
            System.Console.WriteLine();

            // 2. Distributuion properties:
            System.Console.WriteLine(@"2. {0} distributuion properties:", poisson);

            // Cumulative distribution function
            System.Console.WriteLine(@"{0} - ?umulative distribution at location '3'", poisson.CumulativeDistribution(3).ToString(" #0.00000;-#0.00000"));

            // Probability density
            System.Console.WriteLine(@"{0} - Probability mass at location '3'", poisson.Probability(3).ToString(" #0.00000;-#0.00000"));

            // Log probability density
            System.Console.WriteLine(@"{0} - Log probability mass at location '3'", poisson.ProbabilityLn(3).ToString(" #0.00000;-#0.00000"));

            // Entropy
            System.Console.WriteLine(@"{0} - Entropy", poisson.Entropy.ToString(" #0.00000;-#0.00000"));

            // Largest element in the domain
            System.Console.WriteLine(@"{0} - Largest element in the domain", poisson.Maximum.ToString(" #0.00000;-#0.00000"));

            // Smallest element in the domain
            System.Console.WriteLine(@"{0} - Smallest element in the domain", poisson.Minimum.ToString(" #0.00000;-#0.00000"));

            // Mean
            System.Console.WriteLine(@"{0} - Mean", poisson.Mean.ToString(" #0.00000;-#0.00000"));
            
            // Median
            System.Console.WriteLine(@"{0} - Median", poisson.Median.ToString(" #0.00000;-#0.00000"));
            
            // Mode
            System.Console.WriteLine(@"{0} - Mode", poisson.Mode.ToString(" #0.00000;-#0.00000"));

            // Variance
            System.Console.WriteLine(@"{0} - Variance", poisson.Variance.ToString(" #0.00000;-#0.00000"));

            // Standard deviation
            System.Console.WriteLine(@"{0} - Standard deviation", poisson.StdDev.ToString(" #0.00000;-#0.00000"));

            // Skewness
            System.Console.WriteLine(@"{0} - Skewness", poisson.Skewness.ToString(" #0.00000;-#0.00000"));
            System.Console.WriteLine();

            // 3. Generate 10 samples of the Poisson distribution
            System.Console.WriteLine(@"3. Generate 10 samples of the Poisson distribution");
            for (var i = 0; i < 10; i++)
            {
                System.Console.Write(poisson.Sample().ToString("N05") + @" ");
            }

            System.Console.WriteLine();
            System.Console.WriteLine();

            // 4. Generate 100000 samples of the Poisson(1) distribution and display histogram
            System.Console.WriteLine(@"4. Generate 100000 samples of the Poisson(1) distribution and display histogram");
            var data = new double[100000];
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = poisson.Sample();
            }

            ConsoleHelper.DisplayHistogram(data);
            System.Console.WriteLine();

            // 5. Generate 100000 samples of the Poisson(4) distribution and display histogram
            System.Console.WriteLine(@"5. Generate 100000 samples of the Poisson(4) distribution and display histogram");
            poisson.Lambda = 4;
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = poisson.Sample();
            }

            ConsoleHelper.DisplayHistogram(data);
            System.Console.WriteLine();

            // 6. Generate 100000 samples of the Poisson(10) distribution and display histogram
            System.Console.WriteLine(@"6. Generate 100000 samples of the Poisson(10) distribution and display histogram");
            poisson.Lambda = 10;
            for (var i = 0; i < data.Length; i++)
            {
                data[i] = poisson.Sample();
            }

            ConsoleHelper.DisplayHistogram(data);
        }
    }
}
