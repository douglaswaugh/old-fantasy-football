using System;
using System.Collections.Generic;
using System.IO;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data.FixtureProviders
{
    public class CsvFileFixtureParser : FixtureParser
    {
        public IEnumerable<Fixture> ParseFixtures(StreamReader reader)
        {
            ScanPastHeader(reader);

            var fixtures = new List<Fixture>();
            string rawFixture;

            while ((rawFixture = reader.ReadLine()) != null)
            {
                fixtures.Add(ParseFixtre(rawFixture));
            }

            return fixtures;
        }

        private Fixture ParseFixtre(string rawResult)
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

        public void ScanPastHeader(StreamReader reader)
        {
            reader.ReadLine();
        }
    }
}