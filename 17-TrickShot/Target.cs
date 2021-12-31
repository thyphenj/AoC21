using System;
namespace _17_TrickShot
{
    public class Target
    {
        public bool YAxis;
        public int TargetValue;
        public int Velocity;
        public int StepCount;

        public Target(int target, int vel, int cnt, bool YAxis = false)
        {
            TargetValue = target;
            Velocity = vel;
            StepCount = cnt;



        }
    }
}
