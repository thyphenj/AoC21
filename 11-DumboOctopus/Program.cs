using System;
using System.IO;
using System.Collections.Generic;

namespace _11_DumboOctopus
{
    class Program
    {
        static Grid grid;

        static void Main(string[] args)
        {
            string filename = "Input.txt";

            grid = new Grid(filename);
            Part1();

            grid = new Grid(filename);
            Part2();
        }

        static void Part1()
        {
            for (int i = 0; i < 100; i++)
            {
                grid.IncrementIndividuals();

                grid.FlashAndIncrementNeighbours();

                grid.AdjustFlashed();
            }
            Console.WriteLine($"Part 1 : {grid.Flashes}");
        }

        static void Part2()
        {
            int step = 0;

            while ( grid.Unsynchronised())
            {
                step++;

                grid.IncrementIndividuals();

                grid.FlashAndIncrementNeighbours();

                grid.AdjustFlashed();
            }
            Console.WriteLine($"Part 2 : {step}");
        }
    }
}