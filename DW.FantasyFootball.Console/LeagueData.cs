namespace DW.FantasyFootball.Console
{
    public class LeagueData
    {
        public int HomeGoalsFor { get; set; }
        public int HomeGoalsAgainst { get; set; }
        public int HomeWins { get; set; }
        public int HomeDraws { get; set; }
        public int HomeLoses { get; set; }
        public int AwayGoalsFor { get; set; }
        public int AwayGoalsAgainst { get; set; }
        public int AwayWins { get; set; }
        public int AwayDraws { get; set; }
        public int AwayLoses { get; set; }
        public int Points;

        public void UpdateHomeData(Fixture fixture)
        {
            HomeGoalsFor += fixture.HomeGoals;
            HomeGoalsAgainst += fixture.AwayGoals;

            if (fixture.HomeGoals < fixture.AwayGoals)
                HomeLoses++;
            else if (fixture.HomeGoals == fixture.AwayGoals)
            {
                Points += 1;
                HomeDraws++;
            }
            else
            {
                Points += 3;
                HomeWins++;
            }
        }

        public void UpdateAwayData(Fixture fixture)
        {
            AwayGoalsFor += fixture.AwayGoals;
            AwayGoalsAgainst += fixture.HomeGoals;

            if (fixture.AwayGoals < fixture.HomeGoals)
                AwayLoses++;
            else if (fixture.AwayGoals == fixture.HomeGoals)
            {
                Points += 1;
                AwayDraws++;
            }
            else
            {
                Points += 3;
                AwayWins++;
            }
        }
    }
}