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

        public decimal GoalsRatioFor(Player player)
        {
            if (player.Goals == 0)
                return 0m;

            /* TODO should I worry about when a player has left? would have to build goals scored from results */
            /* TODO might also want to try and test seeing if taking games played in to consideration improves the accuracy */

            var totalGoals = Convert.ToDecimal(_players.Sum(p => p.Value.Goals));

            return player.Goals / totalGoals;
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

        public override string ToString()
        {
            return string.Format("Name: {0}", _name);
        }
    }
}