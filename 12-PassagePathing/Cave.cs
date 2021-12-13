using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _12_PassagePathing
{
    public class Cave : IEquatable<Cave>
    {
        public string Name;
        public List<Cave> Neighbours;
        public bool Big;
        public Cave(string name)
        {
            Name = name;
            Big = Name[0] <= 'Z';
            Neighbours = new List<Cave>();
        }

        public void AddNeighbour(Cave cave)
        {
            if (!Neighbours.Contains(cave))
                Neighbours.Add(cave);
        }

        public bool Equals([AllowNull] Cave other)
        {
            if (other == null)
                return false;
            return (this.Name.Equals(other.Name));
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            string retval = $"{Name.PadRight(6)} : {(Big ? 'X' : ' ')} {Neighbours.Count,3} (";
            foreach (var c in Neighbours)
                retval += $"{c.Name},";
            retval = retval.Substring(0, retval.Length - 1) + ")";
            return retval;
        }
    }
}
