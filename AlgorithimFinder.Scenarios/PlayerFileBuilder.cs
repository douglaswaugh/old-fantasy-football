using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace AlgorithimFinder.Scenarios
{
    public class PlayerFileBuilder
    {
        public static void AddFixturesToPlayerFile(string playersDirectoryPath, string player, IEnumerable<string> playerFixtures)
        {
            var directory = Directory.CreateDirectory(playersDirectoryPath);

            using (var writer = File.CreateText(Path.Combine(directory.FullName, PlayerData.Ids[player] + ".json")))
            {
                var jsonResults = String.Empty;

                foreach (var playerFixture in  playerFixtures)
                {
                    if (jsonResults != String.Empty)
                        jsonResults += ", ";

                    var jsonResult = playerFixture;

                    jsonResults += jsonResult;
                }

                ScenarioContext.Current["playersDirectoryPath"] = playersDirectoryPath;

                writer.WriteLine(PlayerData.Formats[player], jsonResults);
            }
        }

        public static void WriteBoyceFixturesToFile(string playersDirectoryPath)
        {
            var boyceFixtures = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0, 50, 1]",
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 19, -176, 50, 6]",
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 11, 3157, 50, 1]",
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 1, 0, 0, 0, 4, -172, 50, -1]",
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 76, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, -384, 50, 1]",
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Boyce", boyceFixtures);
        }

        public static void WriteKoneFixturesToFile(string playersDirectoryPath)
        {
            var koneFixtures = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 65, 1]",
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 3, 20, -228, 65, 6]",
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 14, 3784, 65, 5]",
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, -207, 65, 2]",
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 1, 0, 0, 2, 0, 0, 0, 0, 1, 0, 0, 27, -626, 65, 6]",
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Kone", koneFixtures);
        }

        public static void WriteMaloneyFixturesToFile(string playersDirectoryPath)
        {
            var maloney = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 47, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 7, 0, 50, 1]",
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 74, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 21, -1162, 50, 7]",
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 1, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 20, 4283, 50, 7]",
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 58, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 6, 10630, 50, 1]",
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 3, 1830, 50, 2]",
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Maloney", maloney);
        }

        public static void WriteMcCarthyFixturesToFile(string playersDirectoryPath)
        {
            var mcCarthyFixtures = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 5, 0, 50, 2]",
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 19, -2277, 50, 3]",
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 1, 0, 2, 0, 0, 0, 1, 0, 0, 0, 5, -2648, 50, 5]",
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 6, -1643, 50, 2]",
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 10, -1000, 49, 2]",
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "McCarthy", mcCarthyFixtures);
        }

        public static void WriteFigueroaFixturesToFile(string playersDirectoryPath)
        {
            var figueroaFixtures = new List<string>
                {
                    @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 9, 0, 45, 1]",
                    @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 2, 24, -4183, 45, 9]",
                    @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 8, 34421, 45, 1]",
                    @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 1, 0, 0, 0, 7, 1773, 45, 0]",
                    @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 1, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0, 10, -3732, 45, 1]",
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Figueroa", figueroaFixtures);
        }

        public static void WriteAlHabsiFixturesToFile(string playersDirectoryPath)
        {
            var alHabsiFixtures = new List<string>
                {
	                @"[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 1]",
	                @"[""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 6, 2, 10]",
	                @"[""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 5, 0, 2]",
	                @"[""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 1, 0, 0, 0, 0, 0, 5]",
	                @"[""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 6, 0, 3]"
                };

            AddFixturesToPlayerFile(playersDirectoryPath, "Al Habsi", alHabsiFixtures);
        }
    }
}

