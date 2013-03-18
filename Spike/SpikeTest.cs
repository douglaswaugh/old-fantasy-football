using System;
using System.IO;
using NUnit.Framework;
using SpikeConsole;

namespace Spike
{
    [TestFixture]
    public class SpikeTest
    {
        [Test]
        public void ShouldBeAbleToGrabOutputFromConsoleApp()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                Program.Main(new string[] {"4"});

                var expected = "16" + Environment.NewLine;

                Assert.That(expected, Is.EqualTo(writer.ToString()));
            }
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true});
        }
    }
}
