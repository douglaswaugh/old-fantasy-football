namespace DW.FantasyFootball.Console
{
    public class GamesweekPrinter
    {
        public GamesWeek Gamesweek;

        public GamesweekPrinter(GamesWeek gamesWeek)
        {
            Gamesweek = gamesWeek;
        }

        public void Print()
        {
            foreach (var fixture in Gamesweek)
            {
                System.Console.WriteLine(string.Format("{0}: {1} vs {2}", fixture.Date.ToString("ddMMyyyy"), fixture.HomeTeam.Name, fixture.AwayTeam.Name));
            }
        }
    }
}