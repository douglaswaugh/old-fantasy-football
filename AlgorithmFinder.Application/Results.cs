using System.Collections;
using System.Collections.Generic;

namespace AlgorithmFinder.Application
{
    public class Results : IEnumerable<Result>, IResults
    {
        private readonly List<Result> _results = new List<Result>();

        public Results(List<Result> results)
        {
            _results = results;
        }

        public void Add(Result result)
        {
            _results.Add(result);
        }

        public IEnumerator<Result> GetEnumerator()
        {
            return _results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public double ExpectedHomeGoals(Team homeTeam, Team awayTeam)
        {
            var homeGoalsBaseLine = HomeGoalsBaseLine();
            var homeTeamAttackStrength = AttackStrengthOf(homeTeam);
            var awayTeamDefenceWeakness = DefenceWeaknessOf(awayTeam);

            return homeTeamAttackStrength * awayTeamDefenceWeakness * homeGoalsBaseLine;
        }

        public double ExpectedAwayGoals(Team homeTeam, Team awayTeam)
        {
            var awayGoalsBaseLine = AwayGoalsBaseLine();
            var homeTeamDefenceWeakness = DefenceWeaknessOf(homeTeam);
            var awayTeamAttackStrength = AttackStrengthOf(awayTeam);

            return awayTeamAttackStrength * homeTeamDefenceWeakness * awayGoalsBaseLine;
        }

        private double DefenceWeaknessOf(Team homeTeam)
        {
            return 0;
        }

        private double AttackStrengthOf(Team homeTeam)
        {
            return 0;
        }

        private double AwayGoalsBaseLine()
        {
            return 0;
        }

        private double HomeGoalsBaseLine()
        {
            return 0;
        }
    }
}