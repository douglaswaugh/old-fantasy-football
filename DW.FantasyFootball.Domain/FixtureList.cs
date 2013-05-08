using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace DW.FantasyFootball.Domain
{
    public class FixtureList : IEnumerable<Gamesweek>
    {
        private readonly List<Gamesweek> _gamesweeks;

        public FixtureList()
        {
            _gamesweeks = new List<Gamesweek>();
        }

        public IEnumerator<Gamesweek> GetEnumerator()
        {
            return _gamesweeks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Gamesweek gamesweek)
        {
            _gamesweeks.Add(gamesweek);
        }

        private Gamesweek NextGamesweek()
        {
            return _gamesweeks.FirstOrDefault(g => g.Started == false);
        }

        public override string ToString()
        {
            return String.Format("Gamesweeks: {0}", _gamesweeks);
        }

        public IEnumerable<Fixture> GetLastXHomeFixturesForTeam(Team team, int fixtureCount)
        {
            var homeGames = _gamesweeks
                .Where(g => g.Completed)
                .SelectMany(c => c.GetFixturesForTeam(team))
                .Where(f => f.HomeTeam == team).ToList();

            return homeGames.Skip(homeGames.Count() - fixtureCount);
        }

        public IEnumerable<Fixture> GetLastXAwayFixturesForTeam(Team team, int fixtureCount)
        {
            var awayGames = _gamesweeks
                .Where(g => g.Completed)
                .SelectMany(c => c.GetFixturesForTeam(team))
                .Where(f => f.AwayTeam == team).ToList();

            return awayGames.Skip(awayGames.Count() - fixtureCount);
        }

        public IEnumerable<Fixture> GetNextFixtures(Team team, int numberOfGamesweeks)
        {
            return _gamesweeks
                .Skip(_gamesweeks.IndexOf(NextGamesweek()))
                .Take(numberOfGamesweeks)
                .Where(g => g.GetFixturesForTeam(team).Any())
                .SelectMany(g => g.GetFixturesForTeam(team));
        }

        public void Save()
        {
            var dataContractFixtureList = _gamesweeks.Select(gamesweek => new DataContracts.Gamesweek
            {
                Completed = gamesweek.Completed,
                Fixtures = gamesweek.Fixtures,
                Started = gamesweek.Started
            });
            
            var directory = Directory.CreateDirectory(String.Format(@"c:\apps\DW.FantasyFootball\data\fixtures\{0}", DateTime.Now.ToString("yyyyMMddHHmmss")));

            var i = 1;

            foreach (var gamesweek in dataContractFixtureList)
            {
                var serializer = new DataContractJsonSerializer(typeof(DataContracts.Gamesweek));

                using (var file = File.Create(Path.Combine(directory.FullName, i + ".json")))
                {
                    serializer.WriteObject(file, gamesweek);
                }

                i++;
            }
        }

        public static FixtureList For(int gamesweek, int count, int year)
        {
            return new FixtureList();
        }
    }
}