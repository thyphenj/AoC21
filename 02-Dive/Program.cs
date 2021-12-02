using System;
using System.IO;

namespace _02_Dive
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test data
            //string[] input = { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };

            string[] input = ReadInput("input.txt");

            //-----------------------------------------------------------
            // -- Part 1 : Find position by Depth
            {
                int pos = 0;
                int depth = 0;

                foreach (string comm in input)
                {
                    string[] tokens = comm.Split(' ');
                    switch (tokens[0][0])
                    {
                        case 'f':
                            pos += int.Parse(tokens[1]);
                            break;
                        case 'u':
                            depth -= int.Parse(tokens[1]);
                            break;
                        case 'd':
                            depth += int.Parse(tokens[1]);
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine($"Part 1 : {pos * depth}"); ;
            }
            //-----------------------------------------------------------
            // -- Part 2 : Find position by AIM
            {
                int pos = 0;
                int depth = 0;

                int aim = 0;

                foreach (string comm in input)
                {
                    string[] tokens = comm.Split(' ');
                    int amt = int.Parse(tokens[1]);

                    switch (tokens[0][0])
                    {
                        case 'f':
                            pos += amt;
                            depth += (aim * amt);
                            break;
                        case 'u':
                            aim -= amt;
                            break;
                        case 'd':
                            aim += amt;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine($"Part 2 : {pos * depth}");
            }
        }

        internal static string[] ReadInput(string filename)
        {
            string[] input = File.ReadAllLines(filename);

            return input;
        }
    }
}
