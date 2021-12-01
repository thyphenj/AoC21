using System;
using System.IO;

namespace AoC21
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            int inc = 0;
            int i = 0;
            int cur = int.Parse(input[i++]);
            while (i < input.Length)
            {
                if (int.Parse(input[i - 1]) < int.Parse(input[i]))
                    inc++;
                i++;
            }
            Console.WriteLine(inc);

            inc = 0;
            i = 0;
            cur = int.Parse(input[i]) + int.Parse(input[i + 1]) + int.Parse(input[i + 2]);
            int nxt = int.Parse(input[i + 1]) + int.Parse(input[i + 2]) + int.Parse(input[i + 3]);
            while (i + 3 < input.Length)
            {
                if (cur < nxt)
                    inc++;
                i++;
                cur = nxt;
                if (i + 3 < input.Length)
                    nxt = int.Parse(input[i + 1]) + int.Parse(input[i + 2]) + int.Parse(input[i + 3]);
            }
            Console.WriteLine(inc);


        }
    }
}
