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

            Console.WriteLine();
        }

        static int MaxHeightWillHitXY()
        {
            int maxheight = 0;

            var hitters = new HashSet<(Target,Target)>();

            for (int x = Xmin; x < Xmax; x++)
            {
                foreach (var tx in XHitters.Where(s => s.TargetValue == x))
                {
                    for (int y = Ymin; y < Ymax; y++)
                    {
                        foreach (var ty in YHitters.Where(s => s.TargetValue == y))
                        {
                            if (tx.StepCount == ty.StepCount)
                            {
                                int height = ty.Velocity * (ty.Velocity + 1) / 2;
                                if (height > maxheight)
                                    maxheight = height;
                                hitters.Add((tx, ty));
                            }
                        }
                    }
                }
            }
            return maxheight;
        }

        static HashSet<Target> WillHitX()
        {
            var retval = new HashSet<Target>();

            for (int xVelocity = Xmin; xVelocity <= Xmax; xVelocity++)
            {
                for (int i = 1; i < triang.Length; i++)
                {
                    for (int j = 1; j < i; j++)
                    {
                        if (xVelocity == (triang[i] - triang[j]))
                            retval.Add(new Target(xVelocity, i, i - j));
                    }
                }
            }
            Console.WriteLine("---X HITTERS---");
            foreach (var p in retval)
            {
                Console.Write($"{p.TargetValue,3} in {p.StepCount,2} steps - {p.Velocity,3}    ");
                int total = p.Velocity;
                int sub = 1;
                while (total < p.TargetValue)
                {
                    total += (p.Velocity - sub);
                    Console.Write($"{total,3}  ");
                    sub++;
                }
                Console.WriteLine();
            }
            return retval;
        }

        static HashSet<Target> WillHitY()
        {
            var retval = new HashSet<Target>();

            for (int yVelocity = Ymin; yVelocity <= Ymax; yVelocity++)
            {
                for (int i = 1; i < triang.Length; i++)
                {
                    for (int j = 1; j < i; j++)
                    {
                        if (yVelocity == (triang[j] - triang[i]))
                        {
                            retval.Add(new Target(yVelocity, vel: j, cnt: i + j, YAxis: true));
                        }
                    }
                }
            }
            Console.WriteLine("---Y HITTERS---");
            foreach (var p in retval)
            {
                Console.Write($"{p.TargetValue,3} in {p.StepCount,3} steps - {p.Velocity,3}    ");
                int total = p.Velocity;
                int sub = 1;
                while (total > p.TargetValue)
                {
                    total += (p.Velocity - sub);
                    //if (total < 0)
                        Console.Write($"{total,3}  ");

                    sub++;
                }
                Console.WriteLine();
            }
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
