using System;
using System.Collections.Generic;
using System.IO;

namespace _06_Lanternfish
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");

            //--------------------------------------------------
            //-- Part 1 : 80 days
            for (int i = 0; i < 80; i++)
            {
                input = input.Replace('0', 'X');

                input = input.Replace('1', '0');
                input = input.Replace('2', '1');
                input = input.Replace('3', '2');
                input = input.Replace('4', '3');
                input = input.Replace('5', '4');
                input = input.Replace('6', '5');
                input = input.Replace('7', '6');
                input = input.Replace('8', '7');

                input = input.Replace("X", "6,8");
            }

            string[] str = input.Split(',');
            Console.WriteLine(str.Length);

            //--------------------------------------------------
            //-- Part 2 : 256 days
            List<int> fishes = new List<int>() { 1 };
            long[] count = new long[257];

            for (int i = 1; i <= 10; i++)
            {
                int tail = 0;
                List<int> next = new List<int>();

                foreach (var n in fishes)
                {
                    if (n == 0)
                    {
                        next.Add(6);
                        tail++;
                    }
                    else
                    {
                        next.Add(n - 1);
                    }
                }
                fishes = next;
                for (int j = 0; j < tail; j++)
                    fishes.Add(8);

                count[i] = fishes.Count;
            }
            for ( int i = 11; i <= 256; i++)
            { 
                count[i] = count[i - 9] + count[i - 7];
            }

            long sum = 0;
            foreach (int n in new int[] { 1, 1, 1, 3, 3, 2, 1, 1, 1, 1, 1, 4, 4, 1, 4, 1, 4, 1, 1, 4, 1, 1, 1, 3, 3, 2, 3, 1, 2, 1, 1, 1, 1, 1, 1, 1, 3, 4, 1, 1, 4, 3, 1, 2, 3, 1, 1, 1, 5, 2, 1, 1, 1, 1, 2, 1, 2, 5, 2, 2, 1, 1, 1, 3, 1, 1, 1, 4, 1, 1, 1, 1, 1, 3, 3, 2, 1, 1, 3, 1, 4, 1, 2, 1, 5, 1, 4, 2, 1, 1, 5, 1, 1, 1, 1, 4, 3, 1, 3, 2, 1, 4, 1, 1, 2, 1, 4, 4, 5, 1, 3, 1, 1, 1, 1, 2, 1, 4, 4, 1, 1, 1, 3, 1, 5, 1, 1, 1, 1, 1, 3, 2, 5, 1, 5, 4, 1, 4, 1, 3, 5, 1, 2, 5, 4, 3, 3, 2, 4, 1, 5, 1, 1, 2, 4, 1, 1, 1, 1, 2, 4, 1, 2, 5, 1, 4, 1, 4, 2, 5, 4, 1, 1, 2, 2, 4, 1, 5, 1, 4, 3, 3, 2, 3, 1, 2, 3, 1, 4, 1, 1, 1, 3, 5, 1, 1, 1, 3, 5, 1, 1, 4, 1, 4, 4, 1, 3, 1, 1, 1, 2, 3, 3, 2, 5, 1, 2, 1, 1, 2, 2, 1, 3, 4, 1, 3, 5, 1, 3, 4, 3, 5, 1, 1, 5, 1, 3, 3, 2, 1, 5, 1, 1, 3, 1, 1, 3, 1, 2, 1, 3, 2, 5, 1, 3, 1, 1, 3, 5, 1, 1, 1, 1, 2, 1, 2, 4, 4, 4, 2, 2, 3, 1, 5, 1, 2, 1, 3, 3, 3, 4, 1, 1, 5, 1, 3, 2, 4, 1, 5, 5, 1, 4, 4, 1, 4, 4, 1, 1, 2 })
                sum += count[257 - n];

            Console.WriteLine(sum);
        }
    }
}
