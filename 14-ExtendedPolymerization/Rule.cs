using System;
namespace _14_ExtendedPolymerization
{
    public class Rule
    {
        public string Pair;
        public char Addition;

        public Rule(string line)
        {
            Pair = line.Substring(0, 2);
            Addition = line[6];
        }

        public override string ToString()
        {
            return $"{Pair} ==> {Addition}";
        }
    }
}
