using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmFinder.Application
{
    public class Results : IEnumerable<Fixture>, ExpectedGoalsCalculator
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

        public IEnumerator<Fixture> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ExpectedGoals ExpectedGoalsFor(Fixture fixture)
        {
            return new ExpectedGoals(ExpectedHomeGoals(fixture),
                                     ExpectedAwayGoals(fixture));
        }

        public decimal ExpectedHomeGoals(Fixture fixture)
        {
            var homeGoalsBaseLine = HomeGoalsBaseLine();
            var homeTeamAttackStrength = AttackStrengthOf(fixture.HomeTeam);
            var awayTeamDefenceWeakness = DefenceWeaknessOf(fixture.AwayTeam);

            return homeTeamAttackStrength * awayTeamDefenceWeakness * homeGoalsBaseLine;
        }

        public decimal ExpectedAwayGoals(Fixture fixture)
        {
            var awayGoalsBaseLine = AwayGoalsBaseLine();
            var homeTeamDefenceWeakness = DefenceWeaknessOf(fixture.HomeTeam);
            var awayTeamAttackStrength = AttackStrengthOf(fixture.AwayTeam);

            return awayTeamAttackStrength * homeTeamDefenceWeakness * awayGoalsBaseLine;
        }

        private decimal DefenceWeaknessOf(Team team)
        {
            if (AverageGoalsConceded() == 0m)
                return 0m;

            return GoalsConcededPerGameBy(team)/AverageGoalsPerGame();
        }

        private decimal GoalsConcededPerGameBy(Team team)
        {
            return GoalsConcededBy(team)/NumberOfGamesPlayedBy(team);
        }

        private decimal AttackStrengthOf(Team team)
        {
            if (AverageGoalsScored() == 0m)
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
            return _results.Sum(result => result.HomeGoals() + result.AwayGoals());
        }

        private int GoalsConcededBy(Team team)
        {
            return _results.Where(result => result.HasTeam(team)).Sum(result => result.GoalsConcededBy(team));
        }

        private int GoalsScoredBy(Team team)
        {
            return _results.Where(result => result.HasTeam(team)).Sum(result => result.GoalsScoredBy(team));
        }

        private decimal AverageGoalsConceded()
        {
            return AverageGoalsScored();
        }

        private decimal AverageGoalsScored()
        {
            return ((decimal)_results.Sum(result => result.GoalsScored())) / NumberOfTeamsInLeague();
        }

        private int NumberOfTeamsInLeague()
        {
            return _results.Select(r => r.HomeTeam).Union(_results.Select(s => s.AwayTeam)).Count();
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
    }
}