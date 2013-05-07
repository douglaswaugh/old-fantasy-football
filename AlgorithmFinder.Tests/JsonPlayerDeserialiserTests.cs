﻿using AlgorithmFinder.Data;
using NUnit.Framework;

namespace AlgorithmFinder.Tests
{
    [TestFixture]
    public class JsonPlayerDeserialiserTests
    {
        private const string AlHabsi = @"{""transfers_out"": 93912, ""code"": 261854, ""event_total"": 0, ""last_season_points"": 0, ""squad_number"": null, ""transfers_balance"": 328, ""news_updated"": null, ""event_cost"": 49, ""news_added"": null, ""web_name"": ""Al-Habsi"", ""in_dreamteam"": false, ""team_code"": 261854, ""id"": 508, ""shirt_image_url"": ""http://cdn.ismfg.net/static/plfpl/img/shirts/shirt_20_1.png"", ""first_name"": ""Ali"", ""transfers_out_event"": 160, ""element_type_id"": 1, ""max_cost"": 50, ""event_explain"": [[""Minutes played"", 0, 0]], ""selected"": 89343, ""min_cost"": 49, ""fixtures"": {""all"": [[""07 Apr 16:10"", ""Gameweek 32"", ""QPR (A)""], [""17 Apr 19:45"", ""Gameweek 33"", ""Man City (A)""], [""20 Apr 15:00"", ""Gameweek 34"", ""West Ham (A)""], [""27 Apr 15:00"", ""Gameweek 35"", ""Tottenham (H)""], [""04 May 15:00"", ""Gameweek 36"", ""West Brom (A)""], [""07 May 19:45"", ""Gameweek 36"", ""Swansea (H)""], [""12 May 15:00"", ""Gameweek 37"", ""Arsenal (A)""], [""19 May 16:00"", ""Gameweek 38"", ""Aston Villa (H)""]], ""summary"": [[32, ""QPR (A)"", ""07 Apr 16:10""], [33, ""MCI (A)"", ""17 Apr 19:45""], [34, ""WHU (A)"", ""20 Apr 15:00""]]}, ""season_history"": [[""2006/07"", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, 0], [""2007/08"", 900, 0, 0, 0, 12, 0, 0, 0, 0, 0, 41, 3, 0, 39, 44], [""2008/09"", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 39, 0], [""2009/10"", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 39, 0], [""2010/11"", 3060, 0, 1, 7, 49, 0, 1, 0, 0, 0, 121, 7, 0, 41, 125], [""2011/12"", 3420, 0, 0, 8, 62, 0, 4, 0, 1, 0, 130, 1, 363, 45, 138]], ""total_points"": 73, ""type_name"": ""Goalkeeper"", ""team_name"": ""Wigan"", ""status"": ""a"", ""added"": ""2012-07-17T15:37:23 UTC+0000"", ""form"": 0.0, ""shirt_mobile_image_url"": ""http://cdn.ismfg.net/static/plfpl/img/shirts/mobile/shirt_20_1.png"", ""current_fixture"": ""Norwich (H)"", ""now_cost"": 49, ""points_per_game"": 2.6, ""transfers_in"": 77070, ""news"": """", ""original_cost"": 50, ""event_points"": 0, ""news_return"": null, ""fixture_history"": {""all"": [[""19 Aug 13:30"", 1, ""CHE(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 3, 0, 50, 1], [""25 Aug 15:00"", 2, ""SOU(A) 2-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 6, 2, 23, -3440, 50, 10], [""01 Sep 15:00"", 3, ""STK(H) 2-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 5, 0, 11, 17162, 50, 2], [""15 Sep 15:00"", 4, ""MUN(A) 0-4"", 90, 0, 0, 0, 4, 0, 1, 0, 0, 0, 0, 0, 2, -894, 50, 5], [""22 Sep 15:00"", 5, ""FUL(H) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 6, 0, 8, 2934, 50, 3], [""29 Sep 15:00"", 6, ""SUN(A) 0-1"", 90, 0, 0, 0, 1, 0, 0, 0, 0, 0, 2, 0, 4, 79, 50, 2], [""06 Oct 15:00"", 7, ""EVE(H) 2-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 5, 0, 11, -889, 50, 2], [""20 Oct 15:00"", 8, ""SWA(A) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 6, 0, 10, -834, 50, 3], [""27 Oct 15:00"", 9, ""WHU(H) 2-1"", 90, 0, 0, 0, 1, 0, 0, 0, 0, 0, 4, 0, 18, -1121, 50, 3], [""03 Nov 15:00"", 10, ""TOT(A) 1-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 5, 0, 20, -2137, 50, 7], [""10 Nov 15:00"", 11, ""WBA(H) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 3, 0, 5, 2670, 50, 2], [""17 Nov 15:00"", 12, ""LIV(A) 0-3"", 90, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 0, 10, -957, 50, 1], [""24 Nov 15:00"", 13, ""RDG(H) 3-2"", 90, 0, 0, 0, 2, 1, 0, 0, 0, 0, 4, 0, 17, 848, 50, 0], [""28 Nov 20:00"", 14, ""MCI(H) 0-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 3, 0, 5, -2735, 50, 2], [""03 Dec 20:00"", 15, ""NEW(A) 0-3"", 90, 0, 0, 0, 3, 0, 0, 0, 0, 0, 5, 0, 8, 1715, 50, 2], [""08 Dec 15:00"", 16, ""QPR(H) 2-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 8, 154, 50, 1], [""15 Dec 15:00"", 17, ""NOR(A) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 6, 0, 5, -1463, 50, 3], [""22 Dec 12:45"", 18, ""ARS(H) 0-1"", 90, 0, 0, 0, 1, 0, 0, 0, 0, 0, 3, 0, 4, -1902, 50, 3], [""26 Dec 15:00"", 19, ""EVE(A) 1-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 4, -1040, 50, 1], [""29 Dec 15:00"", 20, ""AVL(A) 3-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 18, -1633, 50, 6], [""01 Jan 15:00"", 21, ""MUN(H) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 0, 0, 3, 0, 6, -1005, 50, 1], [""12 Jan 15:00"", 22, ""FUL(A) 1-1"", 90, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 6, -5966, 50, 2], [""19 Jan 15:00"", 23, ""SUN(H) 2-3"", 90, 0, 0, 0, 3, 0, 0, 0, 0, 0, 2, 0, 3, -3353, 50, 1], [""29 Jan 19:45"", 24, ""STK(A) 2-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 6, -4140, 50, 1], [""02 Feb 15:00"", 25, ""SOU(H) 2-2"", 90, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 6, -2324, 50, 1], [""09 Feb 15:00"", 26, ""CHE(A) 1-4"", 90, 0, 0, 0, 4, 0, 0, 0, 0, 0, 8, 0, 7, -2177, 50, 2], [""23 Feb 15:00"", 27, ""RDG(A) 3-0"", 90, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 15, -1316, 50, 6], [""02 Mar 17:30"", 28, ""LIV(H) 0-4"", 90, 0, 0, 0, 4, 0, 0, 0, 0, 0, 1, 0, 2, -582, 50, 0], [""17 Mar 16:00"", 30, ""NEW(H) 2-1"", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -96, 50, 0], [""30 Mar 15:00"", 31, ""NOR(H) 1-0"", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 49, 0]], ""summary"": [[28, ""LIV (H)"", 0], [30, ""NEW (H)"", 0], [31, ""NOR (H)"", 0]]}, ""next_fixture"": ""QPR (A)"", ""transfers_in_event"": 98, ""selected_by"": ""3.4"", ""team_id"": 20, ""second_name"": ""Al Habsi"", ""photo_mobile_url"": ""http://cdn.ismfg.net/static/plfpl/img/shirts/photos/261854.jpg""}";
        
        [Test]
        public void Should_deserialise_fixture_history_for_al_habsi()
        {
            var alHabsi = new JsonPlayerDeserialiser().Deserialise(AlHabsi);

            Assert.That(alHabsi.Saves, Is.EqualTo(0.95555).Within(0.0001m));
            Assert.That(alHabsi.Bonus, Is.EqualTo(0.06666).Within(0.0001m));
        }

        [Test]
        public void Deserialised_fixture_history_should_contain_goals_scored()
        {
            var player = new SerialisedPlayerBuilder()
                .WithId(508)
                .WithName("Figueroa")
                .WithFixture(
                    new SerialisedFixtureBuilder()
                        .WithGoals(2)
                    .Build())
            .Build();

            var deserialisedPlayer = new JsonPlayerDeserialiser().Deserialise(player);

            Assert.That(deserialisedPlayer.Goals, Is.EqualTo(2));
        }

        [Test]
        public void Deserialized_fixture_history_should_contain_assists_made()
        {
            var player = new SerialisedPlayerBuilder()
                .WithId(508)
                .WithName("Figueroa")
                .WithFixture(
                    new SerialisedFixtureBuilder()
                        .WithAssists(2)
                    .Build())
                .Build();

            var deserializedPlayer = new JsonPlayerDeserialiser().Deserialise(player);
            Assert.That(deserializedPlayer.Assists, Is.EqualTo(2));
        }

        [Test]
        public void ShouldDeserialiseIdFromFplPlayer()
        {
            var alHabsi = new JsonPlayerDeserialiser().Deserialise(AlHabsi);

            Assert.That(alHabsi.Id, Is.EqualTo(508));
        }
    }
}