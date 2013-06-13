using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmFinder.Application
{
    public class Team
    {
        private readonly string _name;

        private readonly Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public Team(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player.Id, player);
        }

        public Player GetPlayer(int id)
        {
            return _players[id];
        }

        public decimal GoalsRatioFor(decimal playerGoals)
        {
            if (playerGoals == 0)
                return 0m;

            var totalGoals = Convert.ToDecimal(_players.Sum(p => p.Value.Goals));

            return playerGoals / totalGoals;
        }

        public decimal AssistsRatioFor(Player player)
        {
            if (player.Assists == 0)
                return 0m;

            var totalAssists = Convert.ToDecimal(_players.Sum(p => p.Value.Assists));

            return player.Assists / totalAssists;
        }

        #region Equality

        protected bool Equals(Team other)
        {
            return string.Equals(_name, other._name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Team) obj);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        #endregion

        #region Formatting
        public override string ToString()
        {
            return string.Format("Name: {0}", _name);
        }
        #endregion
    }
}