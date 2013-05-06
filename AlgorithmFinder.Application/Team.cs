using System.Collections.Generic;

namespace AlgorithmFinder.Application
{
    public class Team
    {
        private readonly string _name;
        private readonly int _id;

        private readonly Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public Team(string name, int id)
        {
            _name = name;
            _id = id;
        }

        public Team(int id)
        {
            _id = id;
        }

        public Team(string name)
        {
            _name = name;
        }

        /*public int Id
        {
            get { return _id; }
        }*/

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
            return 0m;
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