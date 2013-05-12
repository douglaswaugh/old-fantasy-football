using System.Collections.Generic;

namespace AlgorithmFinder.Tests
{
    public class SerialisedPlayerBuilder
    {
        private const string SerialisedPlayerFormat = @"{{
""transfers_out"": 110347, 
""code"": 295793, 
""event_total"": 6, 
""last_season_points"": 0, 
""squad_number"": null, 
""transfers_balance"": 8398, 
""news_updated"": null, 
""event_cost"": 43, 
""news_added"": ""2013-02-28T12:31:20 UTC+0000"", 
""web_name"": ""Figueroa"", 
""in_dreamteam"": false, 
""team_code"": 295793, 
""id"": {0}, 
""shirt_image_url"": ""http://cdn.ismfg.net/static/plfpl/img/shirts/shirt_20.png"", 
""first_name"": ""Maynor"", 
""transfers_out_event"": 70, 
""element_type_id"": 2, 
""max_cost"": 45, 
""event_explain"": [[""Clean sheets"", 1, 4], [""Minutes played"", 90, 2]], 
""selected"": 82542, 
""min_cost"": 43, 
""fixtures"": {{""all"": [[""07 Apr 16:10"", ""Gameweek 32"", ""QPR (A)""], [""17 Apr 19:45"", ""Gameweek 33"", ""Man City (A)""], [""20 Apr 15:00"", ""Gameweek 34"", ""West Ham (A)""], [""27 Apr 15:00"", ""Gameweek 35"", ""Tottenham (H)""], [""04 May 15:00"", ""Gameweek 36"", ""West Brom (A)""], [""07 May 19:45"", ""Gameweek 36"", ""Swansea (H)""], [""12 May 15:00"", ""Gameweek 37"", ""Arsenal (A)""], [""19 May 16:00"", ""Gameweek 38"", ""Aston Villa (H)""]], 
""summary"": [[32, ""QPR (A)"", ""07 Apr 16:10""], [33, ""MCI (A)"", ""17 Apr 19:45""], [34, ""WHU (A)"", ""20 Apr 15:00""]]}}, 
""season_history"": [[""2007/08"", 91, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 40, 2], [""2008/09"", 3341, 1, 2, 0, 45, 0, 0, 0, 4, 0, 0, 3, 0, 46, 124], [""2009/10"", 3087, 1, 1, 0, 65, 0, 0, 0, 6, 0, 0, 1, 0, 41, 80], [""2010/11"", 2808, 1, 3, 5, 49, 0, 0, 0, 11, 0, 0, 0, 0, 41, 71], [""2011/12"", 3349, 0, 1, 8, 60, 0, 0, 0, 6, 0, 0, 4, 356, 43, 88]], 
""total_points"": 60, 
""type_name"": ""Defender"", 
""team_name"": ""Wigan"", 
""status"": ""a"", 
""added"": ""2012-07-17T15:37:23 UTC+0000"", 
""form"": 2.7, 
""shirt_mobile_image_url"": ""http://cdn.ismfg.net/static/plfpl/img/shirts/mobile/shirt_20.png"", 
""current_fixture"": ""Norwich (H)"", 
""now_cost"": 43, ""points_per_game"": 2.1, 
""transfers_in"": 83506, 
""news"": """", 
""original_cost"": 45, 
""event_points"": 6, 
""news_return"": ""2012-12-09T00:01:22 UTC+0000"", 
""fixture_history"": 
    {{
        ""all"": [{1}], 
        ""summary"": [[28, ""LIV (H)"", 0], [30, ""NEW (H)"", 2], [31, ""NOR (H)"", 6]]
    }}, ""next_fixture"": ""QPR (A)"", ""transfers_in_event"": 213, ""selected_by"": ""3.2"", ""team_id"": 20, 
""second_name"": ""{2}"", 
""photo_mobile_url"": ""http://cdn.ismfg.net/static/plfpl/img/shirts/photos/295793.jpg""}}";

        private int _id;
        private string _name;
        private List<string> _fixtures = new List<string>();

        public SerialisedPlayerBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public SerialisedPlayerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public SerialisedPlayerBuilder WithFixture(string fixture)
        {
            _fixtures.Add(fixture);
            return this;
        }

        public string Build()
        {
            var fixtures = string.Join(",", _fixtures);

            return string.Format(SerialisedPlayerFormat, _id, fixtures, _name);
        }
    }
}