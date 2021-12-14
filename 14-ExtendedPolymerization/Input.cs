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
        Dictionary<string, long> Pairs;

        public Input(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            LetterCount = new Dictionary<char, int>();
            Pairs = new Dictionary<string, long>();

            Rules = new List<Rule>();
            for (int i = 2; i < lines.Length; i++)
            {
                Rule newRule = new Rule(lines[i]);
                Rules.Add(newRule);
                if (!LetterCount.ContainsKey(newRule.Addition))
                    LetterCount.Add(newRule.Addition, 0);
                Pairs.Add(newRule.Pair, 0);
            }

            Template = lines[0];
            for (int i = 0; i < Template.Length; i++)
            {
                char ch = Template[i];
                if (LetterCount.ContainsKey(ch))
                    LetterCount[ch]++;
                else
                    LetterCount.Add(ch, 1);
                if (i > 0)
                {
                    string pair = Template.Substring(i - 1, 2);
                    Pairs[pair]++;
                }
            }

            Polymer = Template;
        }

        public void Part1()
        {
            for (int i = 1; i <= 10; i++)
            {
                Step_ONE();
            }
            Console.WriteLine($"Part 1 : {FindMaxDifference_ONE()}");
        }

        public void Step_ONE()
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

        private int FindMaxDifference_ONE()
        {
            int min = LetterCount[Rules[0].Addition];
            int max = min;

            foreach (var c in LetterCount)
            {
                if (c.Value < min)
                    min = c.Value;
                if (c.Value > max)
                    max = c.Value;
            }
            return max - min;
        }

        public void Part2()
        {
            for (int i = 1; i <= 40; i++)
            {
                Step_TWO();
            }
            Console.WriteLine($"Part 2 : {FindMaxDifference_TWO()}");
        }

        public void Step_TWO()
        {
            foreach (var p in Pairs.ToList())
            {
                long increment = p.Value;

                //Get two new Pairs
                char newCh = Rules.Where(x => x.Pair == p.Key).FirstOrDefault().Addition;

                string str1 = $"{p.Key[0]}{newCh}";
                string str2 = $"{newCh}{p.Key[1]}";

                Pairs[str1] += increment;
                Pairs[str2] += increment;

                Pairs[p.Key] -= increment;
            }
        }

        private long FindMaxDifference_TWO()
        {
            Dictionary<char, long> sums = new Dictionary<char, long>();
            foreach (var p in Pairs)
            {
                char b = p.Key[1];
                if (sums.ContainsKey(b))
                    sums[b] += p.Value;
                else
                    sums.Add(b, p.Value);
            }
            long? max = null;
            long? min = null;
            foreach (var s in sums)
            {
                if (max == null || s.Value > max)
                    max = s.Value;
                if (min == null || s.Value < min)
                    min = s.Value;
            }

            return (long)(max - min);
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
