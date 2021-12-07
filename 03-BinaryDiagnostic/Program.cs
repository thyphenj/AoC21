using System;
using System.IO;
using System.Collections.Generic;

namespace _03_BinaryDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = GetFileContents("Input.txt");
            //-----------------------------------------------------------
            // -- Part 1 : Find Gamma and Delta

            int wordLength = input[0].Length;

            string gamma = "";
            string delta = "";
            for (int i = 0; i < wordLength; i++)
            {
                char[] mostCommon = MostAndLeastCommonAtPosition(input, i);
                gamma += mostCommon[0];
                delta += mostCommon[1];
            }
            int product = ToInteger(gamma) * ToInteger(delta);

            Console.WriteLine($"Part 1 : {ToInteger(gamma)} {ToInteger(delta)} -> {product}");

            //-----------------------------------------------------------
            // -- Part 2 :

            List<string> ogr = new List<string>(input);
            List<string> csr = new List<string>(input);
            int OGR = 0;
            int CSR = 0;

            for (int i = 0; i < wordLength; i++)
            {
                List<string> ogrKeep = new List<string>();
                List<string> csrKeep = new List<string>();

                char[] digit = MostAndLeastCommonAtPosition(ogr, i);
                foreach (var s in ogr)
                {
                    if (s[i] == digit[0])
                    {
                        ogrKeep.Add(s);
                    }
                }
                digit = MostAndLeastCommonAtPosition(csr, i);
                foreach ( var s in csr)
                { 
                    if (s[i] == digit[1])
                    {
                        csrKeep.Add(s);
                    }
                }
                if (ogrKeep.Count == 1)
                {
                    OGR = ToInteger(ogrKeep[0]);
                    ogrKeep.RemoveAt(0);

                }
                if (csrKeep.Count == 1)
                {
                    CSR = ToInteger(csrKeep[0]);
                    csrKeep.RemoveAt(0);
                }
                ogr = ogrKeep;
                csr = csrKeep;
            }
            Console.WriteLine($"Part 2 : {OGR*CSR}");
        }

        // ------------------------------------------------------------------------------------------------
        static List<string> GetFileContents(string filename)
        {
            List<string> retval = new List<string>();

            foreach (var s in File.ReadAllLines(filename))
            {
                retval.Add(s);
            }
            return retval;
        }

        static char[] MostAndLeastCommonAtPosition(List<string> input, int pos)
        {
            int sum0 = 0;
            int sum1 = 0;
            foreach (var num in input)
            {
                if (num[pos] == '1')
                    sum1++;
                else
                    sum0++;
            }
            if (sum0 > sum1)
                return new char[] { '0', '1' };
            else
                return new char[] { '1', '0' };

        }

        static int ToInteger(string bin)
        {
            int retval = 0;
            foreach (var s in bin)
            {
                retval *= 2;
                if (s == '1')
                    retval += 1;
            }
            return retval;
        }
    }
}
