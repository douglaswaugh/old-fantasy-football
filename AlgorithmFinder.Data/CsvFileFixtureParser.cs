using System;
using System.Collections.Generic;
using System.IO;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public class CsvFileFixtureParser : FixtureParser
    {
        public Fixture ParseFixtre(string rawResult)
        {
            var cells = rawResult.Split(',');
            
            var homeTeam = new Team(cells[0]);
            var awayTeam = new Team(cells[1]);
            var matchDate = DateTime.Parse(cells[2]);
            var score = new Score(Int32.Parse(cells[3]), Int32.Parse(cells[4]));
            
            return new Fixture(
                homeTeam,
                awayTeam,
                matchDate,
                score);
        }

        public IEnumerable<string> ParseFixtures(StreamReader reader)
        {
            ScanPastHeader(reader);

            string rawFixture;

            var rawFixtures = new List<string>();

            while ((rawFixture = reader.ReadLine()) != null)
            {
                rawFixtures.Add(rawFixture);
            }

            return rawFixtures;
        }

        public void ScanPastHeader(StreamReader reader)
        {
            reader.ReadLine();
        }
    }
}