using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _08_SevenSegmentSearch
{
    class Program
    {
        static void Main()
        {
            List<Line> Lines = ReadFileContents("input.txt");

            //----------------------------------------------------------------
            //-- Part 1
            {
                int sum = 0;
                foreach (var line in Lines)
                {
                    foreach (var value in line.Disps)
                    {
                        switch (value.Trim().Length)
                        {
                            case 2:
                            case 4:
                            case 3:
                            case 7:
                                sum++;
                                break;
                            default:
                                break;
                        }
                    }
                }
                Console.WriteLine($"Part 1 : {sum}");
            }
            //----------------------------------------------------------------
            //-- Part 2
            {
                int sum = 0;
                foreach (var line in Lines)
                {
                    string disps = "";
                    string values = "";

                    foreach (var d in line.Disps)
                    {
                        disps += d + " ";
                        values += $"{line.AllSigs.Signals.Where(x => x.SignalStr == d).First().Val}";
                    }
//                    Console.WriteLine($"{disps} : {values}");
                    sum += int.Parse(values);
                }
                Console.WriteLine($"Part 2 : {sum}");
            }
        }

        static List<Line> ReadFileContents(string filename="")
        {
            List<Line> lines = new List<Line>();
            if (filename == "")
                lines.Add(new Line("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"));
            else
            {
                foreach (var line in File.ReadAllLines(filename))
                {
                    lines.Add(new Line(line));
                }
            }

            return lines;
        }
    }
}
