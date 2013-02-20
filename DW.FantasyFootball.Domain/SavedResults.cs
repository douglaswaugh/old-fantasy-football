using System;

namespace DW.FantasyFootball.Domain
{
    public class SavedResults : IResultsStore
    {
        public bool Exists(int gamesweek, int season, int count)
        {
            return false;
        }

        public Results For(int gamesweek, int season, int count)
        {
            return new Results();
        }

        public bool Exists(int gamesweek, int season)
        {

            return false;
        }
    }
}