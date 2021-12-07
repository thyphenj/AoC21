using System;
using System.IO;
using System.Collections.Generic;

namespace _07_TheTreacheryOfWhales
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = "16,1,2,0,4,2,7,1,2,14";
            string input = File.ReadAllText("input.txt");
            List<int> positions = GetValues(input);

            int min = 0;
            int max = 0;
            foreach (var n in positions)
            {
                if (n > max)
                    max = n;
                if (n < min)
                    min = n;
            }
            int leastFuel = int.MaxValue; ;
            int leastTarget = int.MaxValue;
            int leastFuelTri = leastFuel;
            int leastTargetTri = leastTarget;

            for (int target = min; target <= max; target++)
            {
                int fuelUsed = 0;
                int fuelUsedTri = 0;
                foreach ( int n in positions)
                {
                    fuelUsed += Math.Abs(target - n);
                    fuelUsedTri += Triang(Math.Abs(target - n));
                }
                if (fuelUsed < leastFuel)
                {
                    leastFuel = fuelUsed;
                    leastTarget = target;
                }
                if (fuelUsedTri < leastFuelTri)
                {
                    leastFuelTri = fuelUsedTri;
                    leastTargetTri = target;
                }
                Console.WriteLine($"{target,2} {fuelUsed,3}");
            }
            Console.WriteLine();
            Console.WriteLine($"Part 1 : {leastTarget,2} {leastFuel,3}");
            Console.WriteLine($"Part 2 : {leastTargetTri,2} {leastFuelTri,3}");
        }

        static List<int> GetValues ( string str)
        {
            List<int> retval = new List<int>();
            foreach ( string s in str.Split(','))
            {
                retval.Add(int.Parse(s));
            }
            return retval;
        }
        static int Triang ( int n)
        {
            return (n + 1) * n / 2;
        }
    }
}
