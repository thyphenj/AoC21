using System;
using System.Diagnostics;

namespace _17_TrickShot
{
    [DebuggerDisplay("t={TargetValue} c={StepCount} v={Velocity}")]
    public class Target
    {
        public bool YAxis;
        public int TargetValue;
        public int Velocity;
        public int StepCount;
        public bool Repeats;

        public Target(int target, int vel, int cnt, bool yAxis = false)
        {
            TargetValue = target;
            Velocity = vel;
            StepCount = cnt;
            YAxis = yAxis;

            Repeats = vel == cnt;
        }

        public  string ToStr()
        {
            string str = $"{TargetValue,3} in {StepCount,3} steps - {Velocity,3}    ";
            int total = Velocity;
            int sub = 1;
            if (YAxis)
                while (total > TargetValue)
                {
                    total += (Velocity - sub);
                    str += $"{total,3}  ";
                    sub++;
                }
            else
                while (total < TargetValue)
                {
                    total += (Velocity - sub);
                    str += $"{total,3}  ";
                    sub++;
                }
            if (Repeats)
                str += "--->";

            return str;
        }
    }
}
