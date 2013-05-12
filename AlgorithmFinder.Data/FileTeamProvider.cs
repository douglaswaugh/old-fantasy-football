using System;
using System.Collections.Generic;
using System.IO;
using AlgorithmFinder.Application;

namespace AlgorithmFinder.Data
{
    public class FileTeamProvider : TeamProvider
    {
        private readonly PlayerDeserialiser _deserialiser;
        private readonly Streamer _streamer;
        private readonly string _directoryPath;
        private readonly Dictionary<Team, List<string>> _playerProvider;

        public FileTeamProvider(Streamer streamer, PlayerDeserialiser deserialiser, string directoryPath, Dictionary<Team, List<string>> playerProvider)
        {
            _deserialiser = deserialiser;
            _streamer = streamer;
            _directoryPath = directoryPath;
            _playerProvider = playerProvider;
        }

        public Team PopulateTeam(Team team)
        {
            var ids = _playerProvider[team];

            foreach (var id in ids)
            {
                try
                {
                    using (var stream = _streamer.GetStreamReaderFor(Path.Combine(_directoryPath, id + ".json")))
                    {
                        var playerData = stream.ReadToEnd();

                        var player = _deserialiser.Deserialise(playerData, team);

                        team.AddPlayer(player);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File {0}.json could not be found", id);
                }
            }

            return team;
        }
    }
}