using System.Runtime.Serialization;

namespace DW.FantasyFootball.Domain
{
    [DataContract]
    public class Team
    {
        public Team(string teamName)
        {
            Name = teamName;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public bool Equals(Team other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Team)) return false;
            return Equals((Team) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(Team left, Team right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Team left, Team right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}