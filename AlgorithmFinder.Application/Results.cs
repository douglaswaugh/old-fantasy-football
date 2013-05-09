using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmFinder.Application
{
    public class Results : ExpectedGoalsCalculator
    {
        private readonly List<Fixture> _results = new List<Fixture>();

        public Results(List<Fixture> results)
        {
            _results = results;
        }

        public void Add(Fixture result)
        {
            _results.Add(result);
        }

        public int Count()
        {
            return _results.Count();
        }

        public ExpectedGoals ExpectedGoalsFor(Team team, Fixture fixture)
        {
            var home = ExpectedHomeGoals(fixture.HomeTeam, fixture.AwayTeam);
            var away = ExpectedAwayGoals(fixture.HomeTeam, fixture.AwayTeam);

            if (fixture.HomeTeam.Equals(team))
                return new ExpectedGoals(home, away);

            return new ExpectedGoals(away, home);
        }

        private decimal ExpectedHomeGoals(Team homeTeam, Team awayTeam)
        {
            var homeGoalsBaseLine = HomeGoalsBaseLine();
            var homeTeamAttackStrength = AttackStrengthOf(homeTeam);
            var awayTeamDefenceWeakness = DefenceWeaknessOf(awayTeam);

            return homeTeamAttackStrength * awayTeamDefenceWeakness * homeGoalsBaseLine;
        }

        private decimal ExpectedAwayGoals(Team homeTeam, Team awayTeam)
        {
            var awayGoalsBaseLine = AwayGoalsBaseLine();
            var homeTeamDefenceWeakness = DefenceWeaknessOf(homeTeam);
            var awayTeamAttackStrength = AttackStrengthOf(awayTeam);

            return awayTeamAttackStrength * homeTeamDefenceWeakness * awayGoalsBaseLine;
        }

        private decimal DefenceWeaknessOf(Team team)
        {
            if (AverageGoalsPerGame() == 0m)
                return 0m;

            return GoalsConcededPerGameBy(team)/AverageGoalsPerGame();
        }

        private decimal GoalsConcededPerGameBy(Team team)
        {
            return GoalsConcededBy(team)/NumberOfGamesPlayedBy(team);
        }

        private decimal AttackStrengthOf(Team team)
        {
            if (AverageGoalsPerGame() == 0m)
                return 0m;

            return GoalsScoredPerGameBy(team) / AverageGoalsPerGame();
        }

        private decimal GoalsScoredPerGameBy(Team team)
        {
            return GoalsScoredBy(team)/NumberOfGamesPlayedBy(team);
        }

        private decimal NumberOfGamesPlayedBy(Team team)
        {
            return _results.Count(result => result.HasTeam(team));
        }

        private decimal AverageGoalsPerGame()
        {
            return TotalGoalsScored()/(TotalGamesPlayed()*2);
        }

        private decimal TotalGamesPlayed()
        {
            return _results.Count();
        }

        private decimal TotalGoalsScored()
        {
            return _results.Sum(result => result.GoalsScored());
        }

        private int GoalsConcededBy(Team team)
        {
            return _results.Where(result => result.HasTeam(team)).Sum(result => result.GoalsConcededBy(team));
        }

        private int GoalsScoredBy(Team team)
        {
            return _results.Where(result => result.HasTeam(team)).Sum(result => result.GoalsScoredBy(team));
        }

        private decimal AwayGoalsBaseLine()
        {
            decimal awayGoals = _results.Sum(result => result.AwayGoals());

            return awayGoals / _results.Count();
        }

        private decimal HomeGoalsBaseLine()
        {
            decimal homeGoals = _results.Sum(result => result.HomeGoals());

            return homeGoals / _results.Count();
        }

        public IEnumerable<Fixture> Before(DateTime date)
        {
            return _results.Where(r => r.IsBefore(date));
        }

        public IEnumerable<Fixture> After(DateTime date)
        {
            return _results.Where(r => r.IsOnOrAfter(date));
        }
    }
}