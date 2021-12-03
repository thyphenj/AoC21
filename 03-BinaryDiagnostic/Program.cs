using System;
using System.IO;
using System.Collections.Generic;

namespace _03_BinaryDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] originalFile = { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };
            //string[] originalFile = File.ReadAllLines("input.txt");

            List<Number> input = new List<Number>();
            foreach (var str in originalFile)
            {
                input.Add(new Number(str));
            }

            int wordCount = input.Count;
            int wordLength = input[0].ValueAsString.Length;
            //-----------------------------------------------------------
            // -- Part 1 : Find Gamma and Delta

            long[] ones = new long[wordLength];

            //-- Count "set" bits
            foreach (var currWord in input)
            {
                for (int j = 0; j < wordLength; j++)
                {
                    if (currWord.ValueAsString[j] == '1')
                        ones[j]++;
                }
            }

            //-- Convert array to string?!
            long gamma = 0, delta = 0;
            string gammaString = "", deltaString = "";

            for (int i = 0; i < wordLength; i++)
            {
                gamma *= 2;
                delta *= 2;
                if (ones[i] >= wordCount / 2)
                {
                    gamma++;
                    gammaString += '1';
                    deltaString += '0';
                }
                else
                {
                    delta++;
                    gammaString += '0';
                    deltaString += '1';
                }
            }

            Console.WriteLine($"Part 1 : {gamma} {delta} -> {gamma * delta}");

            //-----------------------------------------------------------
            // -- Part 1 : Find Gamma and Delta

            for (int i = 0; i < wordLength; i++)
            {
                foreach (var num in input)
                {
                    if (!num.Removed)
                    {
                        if (num.ValueAsString[i] != gammaString[i])
                        {
                            num.Removed = true;
                        }
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
