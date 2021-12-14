using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _14_ExtendedPolymerization
{
    public class Input
    {
        public string Template;
        public List<Rule> Rules;
        public string Polymer;
        Dictionary<char, int> LetterCount;

        public Input(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            LetterCount = new Dictionary<char, int>();

            Rules = new List<Rule>();
            for (int i = 2; i < lines.Length; i++)
            {
                Rule newRule = new Rule(lines[i]);
                Rules.Add(newRule);
                if (!LetterCount.ContainsKey(newRule.Addition))
                    LetterCount.Add(newRule.Addition, 0);
            }

            Template = lines[0];
            foreach (char ch in Template)
            {
                if (LetterCount.ContainsKey(ch))
                    LetterCount[ch]++;
                else
                    LetterCount.Add(ch, 1);
            }

            Polymer = Template;
        }

        public void Part1()
        {
            Console.Write(" 0)  ");
            foreach (var c in LetterCount)
                Console.Write($"{c.Key}:{c.Value,5}  ");
            Console.WriteLine();

            for (int i = 1; i <= 40; i++)
            {
                Step();
                Console.Write($"{i,2})  ");
                foreach (var c in LetterCount)
                    Console.Write($"{c.Key}:{c.Value,5}  ");
                  Console.WriteLine($"B-H={LetterCount['B']-LetterCount['H'],5}  B-C={LetterCount['B'] - LetterCount['C'],5}");
            }
        }

        public void Step()
        {
            string retval = "";

            for (int i = 1; i < Polymer.Length; i++)
            {
                string substr = Polymer.Substring(i - 1, 2);
                retval += substr[0];

                Rule rule = Rules.Where(x => x.Pair == substr).FirstOrDefault();
                if (rule != null)
                {
                    retval += rule.Addition;
                    LetterCount[rule.Addition]++;
                }
            }
            retval += Polymer[Polymer.Length - 1];

            Polymer = retval;
        }

        public override string ToString()
        {
            string retval = $"{Template}\n\n";
            foreach (var r in Rules)
                retval += $"{r}\n";

            return retval;
        }
    }
}
