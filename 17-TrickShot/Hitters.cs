using System;
using System.Diagnostics;

namespace _17_TrickShot
{
    [DebuggerDisplay("{X.Velocity} {Y.Velocity}")]

    public class Hitters
    {
        public Target X;
        public Target Y;

        public Hitters(Target x, Target y)
        {
            X = x;
            Y = y;
        }
    }
}
