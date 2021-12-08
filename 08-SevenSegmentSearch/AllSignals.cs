using System;
using System.Linq;
using System.Collections.Generic;

namespace _08_SevenSegmentSearch
{
    public class AllSignals
    {
        public List<Signal> Signals;

        public AllSignals()
        {
            Signals = new List<Signal>();
        }
        public void Decypher()
        {
            string num1 = Signals.Where(x => x.SignalStr.Length == 2).First().SignalStr;
            string num7 = Signals.Where(x => x.SignalStr.Length == 3).First().SignalStr;
            string num4 = Signals.Where(x => x.SignalStr.Length == 4).First().SignalStr;
            string num8 = Signals.Where(x => x.SignalStr.Length == 7).First().SignalStr;
            string num9 = "";

            //-- Start off by looking at the length=6 (ie digits 0, 6, 9)
            foreach (var signal in Signals.Where(x => x.Val is null && x.SignalStr.Length == 6))
            {
                if (ContainsAll(signal.SignalStr, num4 + num7))
                {
                    signal.Val = 9;
                    num9 = signal.SignalStr;
                }
            }
            foreach (var signal in Signals.Where(x => x.Val is null && x.SignalStr.Length == 6))
            {
                if ( ContainsAll(signal.SignalStr, num7))
                    signal.Val = 0;
            }
            Signals.Where(x => x.SignalStr.Length == 6 && x.Val is null).First().Val = 6;

            //-- signals of length 5 (ie 2, 3, 5)
            foreach (var signal in Signals.Where(x => x.Val is null && x.SignalStr.Length == 5))
            {
                if ( ContainsAll(signal.SignalStr, num7))
                    signal.Val = 3;
            }
            foreach (var signal in Signals.Where(x => x.Val is null && x.SignalStr.Length == 5))
            {
                if (ContainsAll(num9, signal.SignalStr))
                    signal.Val = 5;
            }
            Signals.Where(x => x.SignalStr.Length == 5 && x.Val is null).First().Val = 2;
            return;
        }
        private bool ContainsAll ( string doesThis, string containThis)
        {
            foreach (char ch in containThis)
            {
                if (!doesThis.Contains(ch))
                {
                    return false;
                }
            }
            return true;
        }
        public void Sort()
        {
            Signals.Sort();
        }

        public void Add(string str)
        {
            Signals.Add(new Signal(OrderIt(str)));
        }

        private string OrderIt(string str)
        {
            string retval = "";
            foreach (char ch in new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' })
                if (str.Contains(ch))
                    retval += ch;

            return retval;
        }


    }
}
