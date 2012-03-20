namespace DW.FantasyFootball.Domain
{
    public class GamesweekPrinter
    {
        public Gamesweek Gamesweek;

        public GamesweekPrinter(Gamesweek gamesweek)
        {
            Gamesweek = gamesweek;
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