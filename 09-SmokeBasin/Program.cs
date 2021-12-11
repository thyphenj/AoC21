using System;
using System.Collections.Generic;
using System.IO;

namespace _09_SmokeBasin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = ReadFileContents("testinput.txt");

            List<Location> lowPoints = new List<Location>();

            //----------------------------------------------------
            //-- Part 1 :
            int sum = 0;
            for (int i = 1; i < input.Count - 1; i++)
            {
                for (int j = 1; j < input[i].Length - 1; j++)
                {
                    if (LowerThanNeighbours(input, i, j))
                    {
                        int val = int.Parse(input[i][j].ToString());
                        lowPoints.Add(new Location(i, j, val));
                        sum += (val + 1);
                        Console.Write(".");
                    }
                    else if (input[i][j] == '9')
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Part 1 : {sum}");

            //----------------------------------------------------
            //-- Part 2 :
            List<int> basins = new List<int>();
            foreach (var p in lowPoints)
            {
                basins.Add(AddLocation(input, p.X, p.Y));
            }
            Console.WriteLine();
        }
        static int AddLocation ( List<string> input, int lineno, int charno)
        {
            int retval = 0;
            if (input[lineno][charno] != '9')
            {
                retval = 1;
                retval += AddLocation(input, lineno, charno - 1);
                retval += AddLocation(input, lineno, charno + 1);
                retval += AddLocation(input, lineno - 1, charno);
                retval += AddLocation(input, lineno + 1, charno);
            }
            return retval;
        }

        static int FindBasinSize(List<string> input, Location loc)
        {
            HashSet<Location> include = new HashSet<Location>();
            include.Add(loc);

            return 0;
        }

        static bool LowerThanNeighbours(List<string> input, int lineno, int charno)
        {
            if (input[lineno][charno] >= input[lineno][charno - 1])
                return false;

            if (input[lineno][charno] >= input[lineno][charno + 1])
                return false;

            if (input[lineno][charno] >= input[lineno - 1][charno])
                return false;

            if (input[lineno][charno] >= input[lineno + 1][charno])
                return false;

            return true; ;
        }

        static List<string> ReadFileContents(string filename)
        {
            var lines = File.ReadAllLines(filename);
            List<string> retval = new List<string>();

            retval.Add(new string('9', lines[0].Length + 2));
            foreach (var line in lines)
            {
                retval.Add($"9{line}9");
            }
            retval.Add(new string('9', lines[0].Length + 2));

            return retval;
        }
    }
}
