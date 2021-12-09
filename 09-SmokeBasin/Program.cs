using System;
using System.Collections.Generic;
using System.IO;

namespace _09_SmokeBasin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = ReadFileContents("input.txt");

            //----------------------------------------------------
            //-- Part 1 :
            int sum = 0;
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (CheckNeighbours(input, i, j))
                    {
                        sum += (int.Parse(input[i][j].ToString()) + 1);
                        Console.Write(".");
                    }
                    else if ( input[i][j] == '9')
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine(  );
            }

            Console.WriteLine($"Part 1 : {sum}");

            //----------------------------------------------------
            //-- Part 2 :
            List<int> basins = new List<int>();
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (CheckNeighbours(input, i, j))
                    {
                        basins.Add(FindBasinSize(input, i, j));
                    }
                }
            }
        }

        static int FindBasinSize(List<string> input, int lineno, int charno)
        {
           
            return 0;
        }

        static bool CheckNeighbours(List<string> input, int lineno, int charno)
        {
            if (charno > 0 && input[lineno][charno] >= input[lineno][charno - 1])
                return false;

            if (charno + 1 < input[lineno].Length && input[lineno][charno] >= input[lineno][charno + 1])
                return false;

            if (lineno > 0 && input[lineno][charno] >= input[lineno - 1][charno])
                return false;

            if (lineno + 1 < input.Count && input[lineno][charno] >= input[lineno + 1][charno])
                return false;

            return true; ;
        }

        static List<string> ReadFileContents(string filename)
        {
            List<string> retval = new List<string>();
            bool firstLine = true;
            string border = "";
            foreach (var line in File.ReadAllLines(filename))
            {
                if ( firstLine)
                {
                    border = new string('9', line.Length + 2);
                    retval.Add(border);
                    firstLine = false;
                }
                retval.Add($"9{line}9");
            }
            retval.Add(border);

            return retval;
        }
    }
}
