namespace DW.FantasyFootball.Domain
{
    public interface IResultsStore
    {
        bool Exists(int gamesweek, int season, int count);

        Results For(int gamesweek, int season, int count);
        
        bool Exists(int gamesweek, int season);
    }
}