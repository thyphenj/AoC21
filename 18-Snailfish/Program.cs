using System;
using System.Collections.Generic;
using System.IO;

namespace _18_Snailfish
{
    class Program
    {
        //static List<SFnumber> theNumbers = new List<SFnumber>();

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] input = File.ReadAllLines(filename);

            string test = input[0];

            // --- Part 1 -------------------------------------------------------
            for ( int i = 1; i < input.Length; i++)
            {
                string result = Reduce($"[{test},{input[i]}]");
//                Console.WriteLine($"{test} -> {result}");
                test = result;
            }
            SFnumber answer = new SFnumber(new CharStream(test));
            Console.WriteLine($"Part 1 : {answer.Magnitude}");

            // --- Part 2 -------------------------------------------------------
            int maxMag = 0;
            for ( int i = 0; i < input.Length; i++)
            {
                for ( int j = 0; j < input.Length; j++)
                {
                    if ( i != j)
                    {
                        string sum = Reduce($"[{input[i]},{input[j]}]");
                        answer = new SFnumber(new CharStream(sum));
                        if (answer.Magnitude > maxMag)
                            maxMag = answer.Magnitude;
                    }
                }
            }
            Console.WriteLine($"Part 2 : {maxMag}");
        }

        static private string Reduce(string input)
        {
            bool exploded;
            bool split;
            do
            {
                int ptr;

                do
                {
                    exploded = false;

                    // Do we explode?
                    ptr = 0;
                    int bracketCount = 0;
                    while (ptr < input.Length)
                    {
                        char ch = input[ptr++];

                        if (ch == '[' && ++bracketCount == 5)     // We have a fifth bracket!!
                        {
                            //Get left string
                            string preStr = input.Substring(0, ptr - 1);

                            string lft = "";
                            while ("0123456789".Contains(input[ptr]))
                            {
                                lft += input[ptr++];
                            }
                            ptr++;

                            string rit = "";
                            while ("0123456789".Contains(input[ptr]))
                            {
                                rit += input[ptr++];
                            }
                            ptr++;
                            string postStr = input.Substring(ptr);

                            string ret = AddToLastDigit(preStr, lft) + "0" + AddToFirstDigit(postStr, rit);

                            input = ret;

                            exploded = true;
                            break;
                        }
                        else if (ch == ']')
                        {
                            bracketCount--;
                        }
                    }
                }
                while (exploded);

                split = false;

                //Do We Split
                ptr = 0;
                while (ptr < input.Length)
                {
                    int digptr = input.IndexOfAny("0123456789".ToCharArray(), ptr);
                    if (digptr >= 0)
                    {
                        string leftStr = input.Substring(0, digptr);
                        if ("0123456789".Contains(input[digptr + 1]))
                        {
                            int len = 2;
                            while ("0123456789".Contains(input[digptr + len]))
                            {
                                len++;
                            }
                            int num = int.Parse(input.Substring(digptr, len));

                            string ret = $"{leftStr}[{num / 2},{(num + 1) / 2}]{input.Substring(digptr + len)}";

                            input = ret;

                            split = true;
                            break;
                        }
                    }
                    ptr++;
                }
            }
            while (split);

            return input;
        }
        static string AddToFirstDigit(string str, string val)
        {
            string retval = str;

            int ptrStart = retval.IndexOfAny("0123456789".ToCharArray());
            if (ptrStart >= 0)
            {
                int ptrEnd = ptrStart;
                while ("0123456789".Contains(retval[ptrEnd]))
                {
                    ptrEnd++;
                }
                ptrEnd--;
                int sum = int.Parse(str.Substring(ptrStart, ptrEnd - ptrStart + 1)) + int.Parse(val);
                retval = retval.Substring(0, ptrStart) + sum.ToString() + retval.Substring(ptrEnd + 1);
            }
            return retval;
        }
        static string AddToLastDigit(string str, string val)
        {
            // find last number
            string retval = str;

            int ptrEnd = retval.LastIndexOfAny("0123456789".ToCharArray());
            if (ptrEnd >= 0)
            {

                int ptrStart = ptrEnd;
                while ("0123456789".Contains(retval[ptrStart]))
                {
                    ptrStart--;
                }
                ptrStart++;

                int sum = int.Parse(str.Substring(ptrStart, ptrEnd - ptrStart + 1)) + int.Parse(val);
                retval = retval.Substring(0, ptrStart) + sum.ToString() + retval.Substring(ptrEnd + 1);
            }
            return retval;
        }
        static string Reverse(string s)
        {
            // Convert to char array, then call Array.Reverse.
            // ... Finally use string constructor on array.
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
