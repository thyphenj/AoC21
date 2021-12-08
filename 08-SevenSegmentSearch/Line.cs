using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_SevenSegmentSearch
{
    public class Line
    {
        private string Raw;
        public AllSignals AllSigs;
        public List<string> Disps;

        public Line(string line)
        {
            Raw = line;
            AllSigs = new AllSignals();
            Disps = new List<string>();

            string[] tokens = Raw.Split(" | ");
            foreach (var signal in tokens[0].Split(' '))
            {
                AllSigs.Add(signal);
            }
            AllSigs.Sort();
            AllSigs.Decypher();

            foreach (var display in tokens[1].Split(' '))
            {
                Disps.Add(OrderIt(display));
            }
        }

        private string OrderIt(string str)
        {
            string retval = "";
            foreach (char ch in new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' })
                if (str.Contains(ch))
                    retval += ch;

            return retval;
        }

        public override string ToString()
        {
            return Raw;
        }
    }

}
