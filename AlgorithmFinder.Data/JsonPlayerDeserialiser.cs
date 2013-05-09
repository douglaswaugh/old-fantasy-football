﻿using System.Collections.Generic;
using AlgorithmFinder.Application;
using AlgorithmFinder.Application.PointsCalculators;
using Newtonsoft.Json;

namespace AlgorithmFinder.Data
{
    public class JsonPlayerDeserialiser : PlayerDeserialiser
    {
        public Player Deserialise(string playerData)
        {
            var fplPlayer = JsonConvert.DeserializeObject<FplPlayer>(playerData);

            PointsCalculator pointsCalculator;

            switch (fplPlayer.TypeName)
            {
                case "Goalkeeper":
                    pointsCalculator = new GoalkeeperPointsCalculator();
                    break;
                case "Defender":
                    pointsCalculator = new DefenderPointsCalculator();
                    break;
                case "Midfielder":
                    pointsCalculator = new MidfielderPointsCalculator();
                    break;
                case "Forward" :
                    pointsCalculator = new ForwardPointsCalculator();
                    break;
                default:
                    throw new InvalidPlayerTypeException();
            }

            var fixtures = new List<PlayerFixture>();
            
            foreach(var fplFixture in fplPlayer.FixtureHistory["all"])
            {
                var saves = int.Parse(fplFixture[13]);
                var bonus = int.Parse(fplFixture[14]);
                var goals = int.Parse(fplFixture[4]);
                var assists = int.Parse(fplFixture[5]);

                var fixture = new PlayerFixture(saves, bonus, goals, assists);

                fixtures.Add(fixture);
            }

            var player = new Player(fplPlayer.Id, string.Empty, pointsCalculator, new FixtureHistory(fixtures));

            return player;
        }
    }
}