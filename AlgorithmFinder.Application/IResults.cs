namespace AlgorithmFinder.Application
{
    public interface IResults
    {
        double ExpectedHomeGoals(Team homeTeam, Team awayTeam);
        double ExpectedAwayGoals(Team homeTeam, Team awayTeam);
    }
}