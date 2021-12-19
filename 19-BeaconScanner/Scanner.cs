using System;
using System.Collections.Generic;

namespace _19_BeaconScanner
{
    public class Scanner
    {
        public int ScannerId;
        public List<Coord> Coords;

        public Scanner(string str)
        {
            ScannerId = int.Parse(str.Substring(12, 2));
            Coords = new List<Coord>();
        }

        public override string ToString()
        {
            return $"Scanner {ScannerId,2} has {Coords.Count,2} coords";
        }
    }
}
