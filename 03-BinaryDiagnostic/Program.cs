using System;
using System.IO;

namespace _03_BinaryDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            string[] input = File.ReadAllLines("input.txt");

            long[] ones = new long[input[0].Length];
            long[] zros = new long[input[0].Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (input[i][j] == '0')
                        zros[j]++;
                    else
                        ones[j]++;
                }
            }
            long gamma = 0;
            long delta = 0;
            for (int i = 0; i < input[0].Length; i++)
            {
                int digit = (ones[i] > zros[i]) ? 1 : 0;
                    
                gamma = gamma * 2 + digit;
                delta = delta * 2 + (digit + 1) % 2;
            }

            Console.WriteLine($"{gamma} {delta} -> {gamma*delta}");
        }
    }
}
