using System;
using System.IO;

namespace _01_SonarSweep
{
    class Program
    {
        private static void Main()
        {
            //Test data
            //int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            int[] input = ReadInput("input.txt");

            //-----------------------------------------------------------
            // Part 1 - Count the increases
            int inc = 0;
            int i = 1;
            while (i < input.Length)
            {
                if (input[i - 1] < input[i])
                    inc++;
                i++;
            }
            Console.WriteLine($"Part 1 : {inc}");

            //-----------------------------------------------------------
            // Part 2 - Count increases in rolling window of 3
            inc = 0;
            i = 0;
            int cur = input[i] + input[i + 1] + input[i + 2];
            while (i + 3 < input.Length)
            {
                int nxt = input[i + 1] + input[i + 2] + input[i + 3];
                if (cur < nxt)
                    inc++;
                cur = nxt;
                i++;
            }
            Console.WriteLine($"Part 2 : {inc}");
        }

        private static int[] ReadInput(string filename)
        {
            string[] input = File.ReadAllLines("input.txt");

            int[] retval = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                retval[i] = int.Parse(input[i]);
             }
            return retval;
        }
    }
}
