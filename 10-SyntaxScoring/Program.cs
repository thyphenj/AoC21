using System;
using System.Collections.Generic;
using System.IO;

namespace _10_SyntaxScoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ReadInput("input.txt");
            List<Stack<char>> incomplete = new List<Stack<char>>();

            //-----------------------------------------------------------------
            long sum = 0;
            foreach (var s in input)
            {
                bool keep = true;
                Stack<char> stck = new Stack<char>();
                foreach (char c in s)
                {
                    if ("<[{(".Contains(c))
                    {
                        stck.Push(c);
                    }
                    else
                    {
                        char pop = stck.Pop();
                        if (!"<>{}()[]".Contains($"{pop}{c}"))
                        {
                            sum += CharValue(c);
                            keep = false;
                        }
                    }
                }
                if (keep)
                    incomplete.Add(stck);
            }
            Console.WriteLine($"Part 1 : {sum}");

            //-----------------------------------------------------------------
            sum = 0;
            long[] scores = new long[incomplete.Count];
            int i = 0;
            foreach (var s in incomplete)
            {
                while (s.Count > 0)
                {
                    char c = s.Pop();
                    scores[i] = scores[i] * 5 + CharValue(c);
                }
                i++;
            }
            Array.Sort(scores);
            Console.WriteLine($"Part 2 : {scores[scores.Length/2]}");
        }

        private static int CharValue ( char c)
        {
            return c switch
            {
                ')' => 3,
                ']' => 57,
                '}' => 1197,
                '>' => 25137,
                '(' => 1,
                '[' => 2,
                '{' => 3,
                '<' => 4,
                _ => 0
            };
        }

        private static List<string> ReadInput(string input)
        {
            return new List<string>(File.ReadAllLines(input));
        }
    }
}
