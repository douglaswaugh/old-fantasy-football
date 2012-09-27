namespace DW.FantasyFootball.Domain
{
    public class Result
    {
        private readonly Team _homeTeam;
        private readonly Team _awayTeam;
        private readonly int _homeScore;
        private readonly int _awayScore;

        public Result(Team homeTeam, Team awayTeam, int homeScore, int awayScore)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _homeScore = homeScore;
            _awayScore = awayScore;
        }
    }
}