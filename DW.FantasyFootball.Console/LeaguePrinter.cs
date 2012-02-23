using System.Collections.Generic;
using System.Linq;

namespace DW.FantasyFootball.Console
{
    public class LeaguePrinter
    {
        private readonly IEnumerable<KeyValuePair<Team, LeagueData>> _league;

        public LeaguePrinter(IEnumerable<KeyValuePair<Team, LeagueData>> league)
        {
            _league = league;
        }

        public void ByTotalPoints()
        {
            var orderedLeague = _league.OrderByDescending(x => x.Value.Points);

            foreach (var leagueEntry in orderedLeague)
            {
                System.Console.WriteLine(string.Format("{0} {1}", leagueEntry.Key.Name, leagueEntry.Value.Points));
            }
        }

        public void ByHomeGoalsConceededAsc()
        {
            var orderedLeague = _league.OrderBy(x => x.Value.HomeGoalsAgainst);

            System.Console.WriteLine(string.Format("Home goals conceeded"));

            foreach (var leagueEntry in orderedLeague)
            {
               System.Console.WriteLine(string.Format("{0} {1}", leagueEntry.Key.Name, leagueEntry.Value.HomeGoalsAgainst));
            }

            System.Console.WriteLine();
        }

        public void ByHomeGoalsScoredDesc()
        {
            var orderedLeague = _league.OrderByDescending(x => x.Value.HomeGoalsFor);

            System.Console.WriteLine(string.Format("Home goals scored"));

            foreach (var leagueEntry in orderedLeague)
            {
                System.Console.WriteLine(string.Format("{0} {1}", leagueEntry.Key.Name, leagueEntry.Value.HomeGoalsFor));
            }

            System.Console.WriteLine();
        }

        public void ByAwayGoalsConceeded()
        {
            var orderedLeague = _league.OrderBy(x => x.Value.AwayGoalsAgainst);

            System.Console.WriteLine(string.Format("Away goals conceeded"));

            foreach (var leagueEntry in orderedLeague)
            {
                System.Console.WriteLine(string.Format("{0} {1}", leagueEntry.Key.Name, leagueEntry.Value.AwayGoalsAgainst));
            }

            System.Console.WriteLine();
        }

        public void ByAwayGoalsScoredDesc()
        {
            var orderedLeague = _league.OrderBy(x => x.Value.AwayGoalsFor);

            System.Console.WriteLine(string.Format("Away goals scored"));

            foreach (var leagueEntry in orderedLeague)
            {
                System.Console.WriteLine(string.Format("{0} {1}", leagueEntry.Key.Name, leagueEntry.Value.AwayGoalsFor));
            } 
            
            System.Console.WriteLine();
        }
    }
}