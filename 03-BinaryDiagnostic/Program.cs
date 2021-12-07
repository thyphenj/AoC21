using System;
using System.IO;
using System.Collections.Generic;

namespace _03_BinaryDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("testinput.txt");

            List<string> keepers = new List<string>();

            int wordCount = input.Length;
            int wordLength = input[0].Length;
            //-----------------------------------------------------------
            // -- Part 1 : Find Gamma and Delta

            int[] ones = new int[wordLength];

            //-- Count "set" bits
            foreach (var currWord in input)
            {
                keepers.Add(currWord);

                for (int j = 0; j < wordLength; j++)
                {
                    if (currWord[j] == '1')
                        ones[j]++;
                }
            }

            //-- Convert array to string?!
            string gamma = "";
            string delta = "";

            for (int i = 0; i < wordLength; i++)
            {
                if (2*ones[i] > wordCount )
                {
                    gamma += '1';
                    delta += '0';
                }
                else
                {
                    gamma += '0';
                    delta += '1';
                }
            }
            int product = ToInteger(gamma) * ToInteger(delta);
            Console.WriteLine($"Part 1 : {ToInteger(gamma)} {ToInteger(delta)} -> {product}");

            //-----------------------------------------------------------
            // -- Part 2 :

            for (int i = 0 ; i < wordLength; i++)
            {
                char digit = gamma[i];
                foreach (var s in input)
                {
                    if (s[i] != digit)
                        keepers.Remove(s);
                }
                Console.WriteLine($"{i,2} {keepers.Count}");
            }
        }

        static int ToInteger ( string bin)
        {
            int retval = 0;
            foreach ( var s in bin)
            {
                retval *= 2;
                if (s == '1')
                    retval += 1;
            }
            return retval;
        }
    }
}
