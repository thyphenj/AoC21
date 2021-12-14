using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _12_PassagePathing
{
    public class Cave : IEquatable<Cave>
    {
        public string Name;
        public bool Big;
        public bool Visited;
        public int VisitCount;

        public List<Cave> Neighbours;

        public Cave(string name)
        {
            Name = name;
            Big = Name[0] <= 'Z';
            Visited = false;
            VisitCount = 0;
            Neighbours = new List<Cave>();
        }

        public void AddNeighbour(Cave cave)
        {
            if (!Neighbours.Contains(cave))
                Neighbours.Add(cave);
        }

        public void Visit ()
        {
            Visited = true;
            if ( !Big) VisitCount++;
        }

        public void ResetVisit()
        {
            Visited = false;
            VisitCount--;
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
