﻿namespace AlgorithmFinder.Application.PointsCalculators
{
    public class GoalkeeperPointsCalculator : PointsCalculator
    {
        public decimal CalculatePoints(Player player, Multiplier defenceMultiplier, Team team, ExpectedGoals expectedGoals,
                                       Fixture fixture)
        {
            var defensivePoints = (defenceMultiplier.CleanSheet * 4) + (defenceMultiplier.ConcedeTwoOrThree * -1) + (defenceMultiplier.ConcedeFourOrFive * -2);

            var saves = player.Saves;

            var bonus = player.Bonus;

            return defensivePoints + saves + bonus;
        }
    }
}