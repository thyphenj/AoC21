using System;
using System.Diagnostics;

namespace _18_Snailfish
{
    [DebuggerDisplay("char@{Ptr}={theStream[Ptr]}")]
    public class CharStream
    {
        public string theStream;
        public int Ptr;

        public CharStream(string str)
        {
            theStream = str;
            Ptr = 0;
        }

        public bool NextTokenIsDigit()
        {
            return theStream[Ptr] >= '0' && theStream[Ptr] <= '9';
        }

        public int GetInteger()
        {
            int retval = (int)(theStream[Ptr] - '0');
            Ptr += 1;   //Get past the closing brace or internal comma

            return retval;
        }
    }
}
