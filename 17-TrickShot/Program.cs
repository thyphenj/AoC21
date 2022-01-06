using System;
using System.Linq;
using System.Collections.Generic;

namespace _17_TrickShot
{
    class Program
    {
        // these are test values
        static int Xmin;
        static int Xmax;
        static int Ymin;
        static int Ymax;

        static HashSet<Target> XHitters;
        static HashSet<Target> YHitters;

        static int[] triang = new int[300];

        static void Main()
        {
            //Init("target area: x=236..262, y=-78..-58");        // Real Data
            Init("target area: x=20..30, y=-10..-5");             // Test Data

            XHitters = WillHitX();
            YHitters = WillHitY();

            int XY = MaxHeightWillHitXY();

            Console.WriteLine($"Part 1 : {XY}");
        }

        static int MaxHeightWillHitXY()
        {
            int maxheight = 0;

            var hitters = new HashSet<Hitters>();

            for (int x = Xmin; x < Xmax; x++)
            {
                foreach (var tx in XHitters.Where(s => s.TargetValue == x))
                {
                    for (int y = Ymin; y < Ymax; y++)
                    {
                        foreach (var ty in YHitters.Where(s => s.TargetValue == y))
                        {
                            if (tx.StepCount == ty.StepCount || (tx.StepCount < ty.StepCount && tx.Repeats))
                            {
                                int height = ty.Velocity * (ty.Velocity + 1) / 2;
                                if (height > maxheight)
                                    maxheight = height;
                                hitters.Add(new Hitters(tx, ty));
                            }
                        }
                    }
                }
            }
            hitters = hitters.OrderBy(x => x.X.Velocity).OrderBy(x=>x.Y.Velocity).ToHashSet<Hitters>();

            return maxheight;
        }

        static HashSet<Target> WillHitX()
        {
            var retval = new HashSet<Target>();

            for (int xTarget = Xmin; xTarget <= Xmax; xTarget++)
            {
                for (int xVelocity = 1; xVelocity < triang.Length; xVelocity++)
                {
                    for (int j = 0; j < xVelocity; j++)
                    {
                        if (xTarget == (triang[xVelocity] - triang[j]))
                        {
                            retval.Add(new Target(xTarget, xVelocity, xVelocity - j));
                        }
                    }
                }
            }
            retval = retval.OrderBy(x => x.StepCount).ToHashSet<Target>();

            //Console.WriteLine("---X HITTERS---");
            //foreach (var p in retval)
            //{
            //    Console.WriteLine(p.ToStr());
            //}
            return retval;
        }

        static HashSet<Target> WillHitY()
        {
            var retval = new HashSet<Target>();

            for (int yTarget = Ymin; yTarget <= Ymax; yTarget++)
            {
                for (int yVelocity = 1; yVelocity < triang.Length; yVelocity++)
                {
                    for (int j = 0; j < yVelocity; j++)
                    {
                        if (yTarget == (triang[j] - triang[yVelocity]))
                        {
                            retval.Add(new Target(yTarget, vel: j, cnt: yVelocity + j, yAxis: true));
                        }
                    }
                }
            }
            retval = retval.OrderBy(x => x.StepCount).ToHashSet<Target>();

            //Console.WriteLine("---Y HITTERS---");
            //foreach (var p in retval)
            //{
            //    Console.WriteLine(p.ToStr());
            //}
            return retval;
        }

        static void Init(string input)
        {
            string[] str = input.Substring(13).Split(", ");

            string[] tok = str[0].Substring(2).Split("..");
            Xmin = Convert.ToInt16(tok[0]);
            Xmax = Convert.ToInt16(tok[1]);

            tok = str[1].Substring(2).Split("..");
            Ymin = Convert.ToInt16(tok[0]);
            Ymax = Convert.ToInt16(tok[1]);

            for (int i = 1; i < 300; i++)
            {
                triang[i] = (i + 1) * i / 2;
            }
        }
    }
}
