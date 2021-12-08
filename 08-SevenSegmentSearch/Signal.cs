using System;
namespace _08_SevenSegmentSearch
{
    public class Signal : IComparable
    {
        public string SignalStr;
        public int? Val;

        public Signal(string s)
        {
            SignalStr = s;
            switch (SignalStr.Length)
            {
                case 2:
                    Val = 1;
                    break;
                case 4:
                    Val = 4;
                    break;
                case 3:
                    Val = 7;
                    break;
                case 7:
                    Val = 8;
                    break;
                default:
                    break;
            }
        }

        public int CompareTo(object obj)
        {
            Signal signalToCompare = obj as Signal;
            if ( SignalStr.Length < signalToCompare.SignalStr.Length )
                return -1;
            else if (  SignalStr.Length >signalToCompare.SignalStr.Length)
                return 1;
            else
                return 0;
        }
        public override string ToString()
        {
            return $"{SignalStr} ({Val ?? -1})";
        }
    }
}
