using System;
using System.Diagnostics;

namespace _18_Snailfish
{
    [DebuggerDisplay("{X!=null?X.ToString():'.'.ToString()},{Y!=null?Y.ToString():'.'.ToString()}")]
    public class SFnumber
    {
        public int? X;
        public int? Y;

        public SFnumber XsfNum;
        public SFnumber YsfNum;

        public int Magnitude;

        public SFnumber() { }

        public SFnumber(CharStream stream)
        {
            // Get past first brace!
            stream.Ptr++;

            // Grab the X first
            if (stream.NextTokenIsDigit())
            {
                X = stream.GetInteger();
                XsfNum = null;
                Magnitude += 3 * (int)X;
            }
            else
            {
                X = null;
                XsfNum = new SFnumber(stream);
                Magnitude += 3 * XsfNum.Magnitude;
            }

            // Get past the comma

            stream.Ptr++;

            // Now try the Y
            if (stream.NextTokenIsDigit())
            {
                Y = stream.GetInteger();
                YsfNum = null;
                Magnitude += 2 * (int)Y;
            }
            else
            {
                Y = null;
                YsfNum = new SFnumber(stream);
                Magnitude += 2 * YsfNum.Magnitude;
            }

            // Get past the closing brace
            stream.Ptr++;

        }

        public override string ToString()
            =>
            $"[{(X == null ? XsfNum.ToString() : X.ToString())}" +
            $",{(Y == null ? YsfNum.ToString() : Y.ToString())}]";
    }
}
